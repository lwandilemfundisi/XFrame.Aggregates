namespace XFrame.Aggregates.Events
{
    public interface ICommittedDomainEvent
    {
        string AggregateId { get; }
        string Data { get; }
        string Metadata { get; }
        int AggregateSequenceNumber { get; }
    }
}
