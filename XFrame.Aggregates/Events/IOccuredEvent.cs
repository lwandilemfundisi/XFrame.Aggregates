using XFrame.Aggregates.Events.AggregateEvents;

namespace XFrame.Aggregates.Events
{
    public interface IOccuredEvent
    {
        IAggregateEvent AggregateEvent { get; }
        IMetadata Metadata { get; }
    }
}
