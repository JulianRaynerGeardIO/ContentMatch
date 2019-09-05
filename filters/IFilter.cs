using System.Collections.Generic;

namespace jon {
    public interface IFilter<T> {
        List<T> apply(List<InvoiceEntry> invoiceEntries, List<SupplierEntry> supplierEntries);
    }
}