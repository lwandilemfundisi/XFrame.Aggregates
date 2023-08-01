using XFrame.Aggregates.ExecutionResults;

namespace XFrame.Aggregates
{
    public interface IAggregateCreateResult<out TExecutionResult>
        where TExecutionResult : IExecutionResult
    {
        TExecutionResult Result { get; }
    }

    public class AggregateCreateResult<TExecutionResult> : IAggregateCreateResult<TExecutionResult>
            where TExecutionResult : IExecutionResult
    {
        public TExecutionResult Result { get; }

        public AggregateCreateResult(
            TExecutionResult result)
        {
            Result = result;
        }
    }
}
