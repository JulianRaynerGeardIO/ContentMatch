using System.Collections.Generic;

namespace jon {
    public class WordsInFirstPageInvoiceFilter : IFilter<InvoiceEntry>{
        public List<InvoiceEntry> apply(List<InvoiceEntry> invoiceLineEntries, List<SupplierEntry> supplierEntries) {
            List<InvoiceEntry> reduced = new List<InvoiceEntry>();
            invoiceLineEntries.ForEach(invoiceEntry => {
                if(invoiceEntry.page_id==1) {
                    reduced.Add(invoiceEntry);
                }
            });
            return reduced;
        }
    }
}