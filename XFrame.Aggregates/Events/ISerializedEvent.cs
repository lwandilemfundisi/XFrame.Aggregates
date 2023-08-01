namespace XFrame.Aggregates.Events
{
    public interface ISerializedEvent
    {
        string SerializedMetadata { get; }
        string SerializedData { get; }
        int AggregateSequenceNumber { get; }
        IMetadata Metadata { get; }
    }
}