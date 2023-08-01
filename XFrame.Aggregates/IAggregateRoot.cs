using XFrame.Aggregates.Events;
using XFrame.Aggregates.Events.Serializers;
using XFrame.Ids;

namespace XFrame.Aggregates
{
    public interface IAggregateRoot
    {
        IAggregateName Name { get; }

        int Version { get; set; }

        bool IsNew { get; }

        bool HasSourceId(ISourceId sourceId);

        IIdentity GetIdentity();

        IAggregateRoot AsExisting();
    }

    public interface IAggregateRoot<TIdentity> : IAggregateRoot
        where TIdentity : IIdentity
    {
        TIdentity Id { get; set; }
    }
}
