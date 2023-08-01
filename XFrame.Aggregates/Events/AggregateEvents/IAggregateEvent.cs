using XFrame.Ids;
using XFrame.VersionTypes;

namespace XFrame.Aggregates.Events.AggregateEvents
{
    public interface IAggregateEvent : IVersionedType
    {
    }

    public interface IAggregateEvent<TAggregate, TIdentity> : IAggregateEvent
        where TAggregate : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
    }
}
