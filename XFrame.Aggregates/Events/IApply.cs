using XFrame.Aggregates.Events.AggregateEvents;

namespace XFrame.Aggregates.Events
{
    public interface IApply<in TAggregateEvent>
        where TAggregateEvent : IAggregateEvent
    {
        void Apply(TAggregateEvent aggregateEvent);
    }
}