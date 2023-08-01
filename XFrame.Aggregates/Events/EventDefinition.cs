using XFrame.VersionTypes;

namespace XFrame.Aggregates.Events
{
    public class EventDefinition : VersionedTypeDefinition
    {
        public EventDefinition(
            int version,
            Type type,
            string name)
            : base(version, type, name)
        {
        }
    }
}