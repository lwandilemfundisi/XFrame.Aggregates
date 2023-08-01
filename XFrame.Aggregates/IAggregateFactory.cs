using XFrame.Ids;

namespace XFrame.Aggregates
{
    public interface IAggregateFactory
    {
        Task<TAggregate> CreateNewAggregateAsync<TAggregate, TIdentity>(TIdentity id)
            where TAggregate : IAggregateRoot<TIdentity>
            where TIdentity : IIdentity;
    }
}
