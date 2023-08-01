using XFrame.VersionTypes;

namespace XFrame.Aggregates.Events
{
    public interface IEventDefinitionService 
        : IVersionedTypeDefinitionService<EventVersionAttribute, EventDefinition>
    {
    }
}