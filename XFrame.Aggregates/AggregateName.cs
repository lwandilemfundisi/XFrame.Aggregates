using XFrame.ValueObjects.SingleValueObjects;

namespace XFrame.Aggregates
{
    public class AggregateName : SingleValueObject<string>, IAggregateName
    {
        public AggregateName(string value)
            : base(value)
        {

        }
    }
}
