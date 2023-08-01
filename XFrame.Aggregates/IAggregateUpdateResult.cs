using XFrame.Aggregates.ExecutionResults;

namespace XFrame.Aggregates
{
    public interface IAggregateUpdateResult<out TExecutionResult>
        where TExecutionResult : IExecutionResult
    {
        TExecutionResult Result { get; }
    }
}
