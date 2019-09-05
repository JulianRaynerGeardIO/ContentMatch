using System.Collections.Generic;

namespace jon {
    public class WordsInSuppliersInvoiceFilter : IFilter<InvoiceEntry>{
        public List<InvoiceEntry> apply(List<InvoiceEntry> invoiceLineEntries, List<SupplierEntry> supplierEntries) {
            List<InvoiceEntry> reduced = new List<InvoiceEntry>();
            invoiceLineEntries.ForEach(invoiceEntry => {
                if(suppliersContains(invoiceEntry.word, supplierEntries)) {
                    reduced.Add(invoiceEntry);
                }
            });
            return reduced;
        }

        public bool suppliersContains(string searchString, List<SupplierEntry> supplierEntries) {
            foreach(var supplierLineEntry in supplierEntries) {
                if(supplierLineEntry.supplier_name.Contains(searchString)) {
                    return true;
                }
            }
            return false;
        }
    }
}