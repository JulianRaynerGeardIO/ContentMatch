using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace jon {
    public class InvoiceParser : IParser<InvoiceEntry> {
        public List<InvoiceEntry> parse(string[] lines) {
            string json = flattenJsonArray(lines);
            return bindEntries(json);
        }

        public string flattenJsonArray(string [] jsonArray) {
            StringBuilder sb = new StringBuilder("[");
            sb.Append(string.Join(",", jsonArray));
            sb.Append("]");
            return sb.ToString().ToLower();
        }

        public List<InvoiceEntry> bindEntries(string json) {
            return JsonConvert.DeserializeObject<List<InvoiceEntry>>(json);
        }
    }
}