using XFrame.Ids;

namespace XFrame.Aggregates.Events
{
    public interface IEventId : ISourceId
    {
        Guid GetGuid();
    }
}
