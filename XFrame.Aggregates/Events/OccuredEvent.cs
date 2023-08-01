using XFrame.Aggregates.Events.AggregateEvents;

namespace XFrame.Aggregates.Events
{
    public class OccuredEvent : IOccuredEvent
    {
        public IAggregateEvent AggregateEvent { get; }

        public IMetadata Metadata { get; }

        public OccuredEvent(IAggregateEvent aggregateEvent, IMetadata metadata)
        {
            AggregateEvent = aggregateEvent;
            Metadata = metadata;
        }
    }
}
