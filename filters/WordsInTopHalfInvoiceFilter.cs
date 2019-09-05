using System.Collections.Generic;

namespace jon {
    public class WordsInTopHalfInvoiceFilter : IFilter<InvoiceEntry> {
        public List<InvoiceEntry> apply(List<InvoiceEntry> invoiceLineEntries, List<SupplierEntry> supplierEntries) {
            List<InvoiceEntry> reduced = new List<InvoiceEntry>();
            int highestLineAllowed = getNumberLines(invoiceLineEntries)/2;
            invoiceLineEntries.ForEach(invoiceEntry => {
                if(invoiceEntry.line_id<highestLineAllowed) {
                    reduced.Add(invoiceEntry);
                }
            });
            return reduced;
        }

        public int getNumberLines(List<InvoiceEntry> invoiceLineEntries) {
            int highestLine = 0;
            invoiceLineEntries.ForEach(invoiceEntry => {
                if(invoiceEntry.line_id>highestLine) {
                    highestLine=invoiceEntry.line_id;
                }
            });
            return highestLine;
        }
    }
}