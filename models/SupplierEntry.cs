namespace jon {
    public class SupplierEntry {
        public int supplier_id { get; set; }
        public string supplier_name_raw { get; set; }
        

        /* The following are extensions */
        public string supplier_name { get; set; }
        public string[] words { get; set; }
        public override string ToString() { return supplier_name_raw; }
    }
}