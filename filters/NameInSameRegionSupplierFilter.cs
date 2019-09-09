using System.Linq;
using System.Collections.Generic;

namespace jon {
    public class NameInSameRegionSupplierFilter : IFilter<SupplierEntry> {
        public List<SupplierEntry> apply(List<InvoiceEntry> invoiceLineEntries, List<SupplierEntry> supplierEntries) {
            List<SupplierEntry> reduced = new List<SupplierEntry>();
            supplierEntries.ForEach(supplierEntry => {
                //if(onCloseLine(invoiceLineEntries, supplierEntry)) {
                    reduced.Add(supplierEntry);
                //}
            });
            return reduced;
        }

        public bool onCloseLine(List<InvoiceEntry> invoiceLineEntries, SupplierEntry supplier) {
            List<List<InvoiceEntry>> matches = buildWordMap(invoiceLineEntries, supplier);
            return areAnyMatchesOnSimilarLine(matches);
        }

        public List<List<InvoiceEntry>> buildWordMap(List<InvoiceEntry> invoiceLineEntries, SupplierEntry supplier) {
            List<List<InvoiceEntry>> matches = new List<List<InvoiceEntry>>();
            foreach (string word in supplier.words) {
                List<InvoiceEntry> invoiceWordMatches = new List<InvoiceEntry>();
                invoiceLineEntries.ForEach(invoiceEntry => {
                    if(invoiceEntry.word.Equals(word)) {
                        invoiceWordMatches.Add(invoiceEntry);
                    }
                });
                matches.Add(invoiceWordMatches);
            }
            return matches;
        }

        public bool areAnyMatchesOnSimilarLine(List<List<InvoiceEntry>> matches) {
            if(matches.Count==0) return false;
            if(matches.Count==1) return true;

            List<InvoiceEntry> firstWordMatches = matches.First();
            firstWordMatches.ForEach( invoiceEntry => {
                
                matches.ForEach( checkWord => {
                    
                });


                //matches.ForEach( checkWord
            });
            return true;
        }
/* 
        public bool isValidLineValid(int lineId, List<List<InvoiceEntry>> matches) {
            for (var i = 1; i < matches.Count; i++) {
                return true;
            }
            return false;
        }
        */
    }
}