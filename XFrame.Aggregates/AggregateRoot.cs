using Newtonsoft.Json;
using System.Text;
using XFrame.Aggregates.Events;
using XFrame.Aggregates.Events.AggregateEvents;
using XFrame.Aggregates.Extensions;
using XFrame.Common;
using XFrame.Common.Extensions;
using XFrame.Ids;
using XFrame.Ids.Extensions;

namespace XFrame.Aggregates
{
    public abstract class AggregateRoot<TAggregate, TIdentity> : IAggregateRoot<TIdentity>
        where TAggregate : AggregateRoot<TAggregate, TIdentity>
        where TIdentity : IIdentity
    {
        private bool _exists;
        private readonly List<IOccuredEvent> _occuredEvents = new List<IOccuredEvent>();
        private static readonly IAggregateName AggregateName = typeof(TAggregate).GetAggregateName();
        private CircularBuffer<ISourceId> _previousSourceIds = new CircularBuffer<ISourceId>(10);

        protected AggregateRoot(TIdentity id)
        {
            if ((this as TAggregate) == null)
            {
                throw new InvalidOperationException(
                    $"Aggregate '{GetType().PrettyPrint()}' specifies '{typeof(TAggregate).PrettyPrint()}' as generic argument, it should be its own type");
            }

            Id = id;
        }

        public TIdentity Id { get; set; }

        public IAggregateName Name => AggregateName;

        [System.Text.Json.Serialization.JsonIgnore]
        public IEnumerable<IOccuredEvent> OccuredEvents => _occuredEvents;

        public int Version { get; set; }

        public bool IsNew => Version <= 0;

        public IIdentity GetIdentity()
        {
            return Id;
        }

        public bool HasSourceId(ISourceId sourceId)
        {
            return !sourceId.IsNone() && _previousSourceIds.Any(s => s.Value == sourceId.Value);
        }

        protected virtual void Emit<TEvent>(TEvent aggregateEvent, IMetadata metadata = null)
            where TEvent : IAggregateEvent<TAggregate, TIdentity>
        {
            if (aggregateEvent == null)
            {
                throw new ArgumentNullException(nameof(aggregateEvent));
            }

            var aggregateSequenceNumber = Version + 1;
            var eventId = EventId.NewDeterministic(
                GuidFactories.Deterministic.Namespaces.Events,
                $"{Id.Value}-v{aggregateSequenceNumber}");
            var now = DateTimeOffset.Now;
            var eventMetadata = new Events.Metadata
            {
                Timestamp = now,
                AggregateSequenceNumber = aggregateSequenceNumber,
                AggregateName = Name.Value,
                AggregateId = Id.Value,
                EventId = eventId
            };
            eventMetadata.Add(MetadataKeys.TimestampEpoch, now.ToUnixTime().ToString());
            if (metadata != null)
            {
                eventMetadata.AddRange(metadata);
            }

            _occuredEvents.Add(new OccuredEvent(aggregateEvent, eventMetadata));

            Version++;
        }

        public IAggregateRoot AsExisting()
        {
            _exists = true;
            return this;
        }

        private class CommittedDomainEvent : ICommittedDomainEvent
        {
            public long GlobalSequenceNumber { get; set; }
            public string AggregateId { get; set; }
            public string AggregateName { private get; set; }
            public string Data { get; set; }
            public string Metadata { get; set; }
            public int AggregateSequenceNumber { get; set; }

            public override string ToString()
            {
                return new StringBuilder()
                    .AppendLineFormat("{0} v{1} ==================================", AggregateName,
                        AggregateSequenceNumber)
                    .AppendLine(PrettifyJson(Metadata))
                    .AppendLine("---------------------------------")
                    .AppendLine(PrettifyJson(Data))
                    .Append("---------------------------------")
                    .ToString();
            }

            private static string PrettifyJson(string json)
            {
                try
                {
                    var obj = JsonConvert.DeserializeObject(json);
                    var prettyJson = JsonConvert.SerializeObject(obj, Formatting.Indented);
                    return prettyJson;
                }
                catch (Exception)
                {
                    return json;
                }
            }
        }
    }
}
