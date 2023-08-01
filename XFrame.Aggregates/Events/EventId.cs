using XFrame.Ids;

namespace XFrame.Aggregates.Events
{
    public class EventId : Identity<EventId>, IEventId
    {
        public EventId(string value) : base(value)
        {
        }
    }
}
