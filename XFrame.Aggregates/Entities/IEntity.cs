using XFrame.Ids;

namespace XFrame.Aggregates.Entities
{
    public interface IEntity
    {
        IIdentity GetIdentity();
    }

    public interface IEntity<out TIdentity> : IEntity
        where TIdentity : IIdentity
    {
        TIdentity Id { get; }
    }
}
