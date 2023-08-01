using XFrame.Aggregates.Events;
using XFrame.Aggregates.ExecutionResults;

namespace XFrame.Aggregates
{
    public class AggregateUpdateResult<TExecutionResult> : IAggregateUpdateResult<TExecutionResult>
            where TExecutionResult : IExecutionResult
    {
        public TExecutionResult Result { get; }

        public IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

        public AggregateUpdateResult(
            TExecutionResult result,
            IReadOnlyCollection<IDomainEvent> domainEvents)
        {
            Result = result;
            DomainEvents = domainEvents;
        }
    }
}
