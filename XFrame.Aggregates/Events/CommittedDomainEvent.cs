using Newtonsoft.Json;
using System.Text;
using XFrame.Common.Extensions;

namespace XFrame.Aggregates.Events
{
    public class CommittedDomainEvent : ICommittedDomainEvent
    {
        public long GlobalSequenceNumber { get; set; }
        public string AggregateId { get; set; }
        public string AggregateName { private get; set; }
        public string Data { get; set; }
        public string Metadata { get; set; }
        public int AggregateSequenceNumber { get; set; }

        public override string ToString()
        {
            return new StringBuilder()
                .AppendLineFormat("{0} v{1} ==================================", AggregateName,
                    AggregateSequenceNumber)
                .AppendLine(PrettifyJson(Metadata))
                .AppendLine("---------------------------------")
                .AppendLine(PrettifyJson(Data))
                .Append("---------------------------------")
                .ToString();
        }

        private static string PrettifyJson(string json)
        {
            try
            {
                var obj = JsonConvert.DeserializeObject(json);
                var prettyJson = JsonConvert.SerializeObject(obj, Formatting.Indented);
                return prettyJson;
            }
            catch (Exception)
            {
                return json;
            }
        }
    }
}
