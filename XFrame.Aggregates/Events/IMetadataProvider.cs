using XFrame.Aggregates.Events.AggregateEvents;
using XFrame.Ids;

namespace XFrame.Aggregates.Events
{
    public interface IMetadataProvider
    {
        IEnumerable<KeyValuePair<string, string>> ProvideMetadata<TAggregate, TIdentity>(
            TIdentity id,
            IAggregateEvent aggregateEvent,
            IMetadata metadata)
            where TAggregate : IAggregateRoot<TIdentity>
            where TIdentity : IIdentity;
    }
}