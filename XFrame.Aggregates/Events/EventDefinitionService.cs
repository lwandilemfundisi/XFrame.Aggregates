using Microsoft.Extensions.Logging;
using System.Reflection;
using XFrame.Aggregates.Events.AggregateEvents;
using XFrame.Ioc.Configuration;
using XFrame.VersionTypes;

namespace XFrame.Aggregates.Events
{
    public class EventDefinitionService : VersionedTypeDefinitionService<IAggregateEvent, EventVersionAttribute, EventDefinition>, IEventDefinitionService
    {
        public EventDefinitionService(
            ILogger<EventDefinitionService> logger,
            ILoadedTypes loadedTypes)
            : base(logger)
        {
            var eventTypes = loadedTypes
                .TypesLoaded
                .Where(t => typeof(IAggregateEvent).GetTypeInfo().IsAssignableFrom(t));
            Load(eventTypes.ToArray());
        }

        protected override EventDefinition CreateDefinition(int version, Type type, string name)
        {
            return new EventDefinition(version, type, name);
        }
    }
}