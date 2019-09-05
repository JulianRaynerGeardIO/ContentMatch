using System;
using System.Collections.Generic;

namespace jon {
    public class SuppliersParser : IParser<SupplierEntry> {
        public List<SupplierEntry> parse(string[] lines) {
            List<SupplierEntry> list = new List<SupplierEntry>();
            Array.ForEach(lines, element => {
                SupplierEntry entry = bindEntry(element);
                if(entry!=null) {
                    list.Add(entry);
                }
            });
            return list;
        }

        private SupplierEntry bindEntry(string lineString) {
            string[] tokens = lineString.Split(',');
            if(tokens.Length!=2) {
                return null;
            }

            SupplierEntry entry = new SupplierEntry();
            if (Int32.TryParse(tokens[0], out int numValue)) {
                entry.supplier_id = numValue;
                entry.supplier_name_raw = tokens[1];
                entry.supplier_name = tokens[1].ToLower();
                entry.words = entry.supplier_name.Split(' ');
                return entry;
            }

            return null;
        }
    }
}