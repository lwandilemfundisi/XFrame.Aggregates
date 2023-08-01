using System.Collections.Concurrent;
using System.Reflection;
using XFrame.Common.Extensions;

namespace XFrame.Aggregates.Extensions
{
    public static class DomainTypeExtensions
    {
        private static readonly ConcurrentDictionary<Type, AggregateName> AggregateNames = new ConcurrentDictionary<Type, AggregateName>();

        public static AggregateName GetAggregateName(
            this Type aggregateType)
        {
            return AggregateNames.GetOrAdd(
                aggregateType,
                t =>
                {
                    if (!typeof(IAggregateRoot).GetTypeInfo().IsAssignableFrom(aggregateType))
                    {
                        throw new ArgumentException($"Type '{aggregateType.PrettyPrint()}' is not an aggregate root");
                    }

                    return new AggregateName(
                        t.GetTypeInfo().GetCustomAttributes<AggregateNameAttribute>().SingleOrDefault()?.Name ??
                        t.Name);
                });
        }

    }
}
