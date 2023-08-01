using XFrame.Ids;
using XFrame.ValueObjects;

namespace XFrame.Aggregates.Entities
{
    public class Entity<TIdentity> : ValueObject, IEntity<TIdentity>
        where TIdentity : IIdentity
    {
        public TIdentity Id { get; set; }

        public IIdentity GetIdentity()
        {
            return Id;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}
