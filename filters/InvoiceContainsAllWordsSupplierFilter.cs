using System.Collections.Generic;

namespace jon {
    public class InvoiceContainsAllWordsSupplierFilter : IFilter<SupplierEntry> {
        public List<SupplierEntry> apply(List<InvoiceEntry> invoiceLineEntries, List<SupplierEntry> supplierEntries) {
            List<SupplierEntry> reduced = new List<SupplierEntry>();
            supplierEntries.ForEach(supplierEntry => {
                if(containsAll(supplierEntry.words, invoiceLineEntries)) {
                    reduced.Add(supplierEntry);
                }
            });
            return reduced;
        }

        public bool containsAll(string[] words, List<InvoiceEntry> entries) {
            foreach(string word in words) {
                if(!contains(word, entries)) {
                    return false;
                }
            }
            return true;
        }
        public bool contains(string searchString, List<InvoiceEntry> entries) {
            foreach (var entry in entries) {
                if(entry.word.Equals(searchString)) {
                    return true;
                }
            }
            return false;
        }
    }
}