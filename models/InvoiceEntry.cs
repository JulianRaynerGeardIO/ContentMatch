namespace jon {
    public class InvoiceEntry {
        public int pos_id { get; set; }
        public string word { get; set; }
        public int line_id { get; set; }
        public int page_id { get; set; }

        /* The following are extensions */
        public override string ToString() { return word; }
    }
}