﻿using System;
using System.Collections.Generic;

namespace jon {
    class Program {
        static void Main(string[] args) {
            List<SupplierEntry> supplierEntries = new FileReader<SupplierEntry>().read("assets/suppliernames.txt", new SuppliersParser());
            List<InvoiceEntry> invoiceEntries = new FileReader<InvoiceEntry>().read("assets/invoice.txt", new InvoiceParser());
            getInvoiceFilters().ForEach(filter => { invoiceEntries = filter.apply(invoiceEntries, supplierEntries); });
            getSupplierFilters().ForEach(filter => {supplierEntries  = filter.apply(invoiceEntries, supplierEntries); });

            Console.WriteLine("Match Count: " + supplierEntries.Count);
            Console.WriteLine("Matches: " + string.Join("\n", supplierEntries));
        }

        static List<IFilter<InvoiceEntry>> getInvoiceFilters() {
            List<IFilter<InvoiceEntry>> filters = new List<IFilter<InvoiceEntry>>();
            filters.Add(new WordsInFirstPageInvoiceFilter());
            filters.Add(new WordsInTopHalfInvoiceFilter());
            filters.Add(new WordsInSuppliersInvoiceFilter());
            return filters;
        }

        static List<IFilter<SupplierEntry>> getSupplierFilters() {
            List<IFilter<SupplierEntry>> filters = new List<IFilter<SupplierEntry>>();
            filters.Add(new InvoiceContainsAllWordsSupplierFilter());
            filters.Add(new NameInSameRegionSupplierFilter());
            return filters;
        }
    }
}



/*
// build for different platforms
dotnet publish -c Release -r win10-x64
dotnet publish -c Release -r osx.10.14-x64
dotnet publish -c Release -r ubuntu.16.10-x64
https://docs.microsoft.com/en-us/dotnet/core/rid-catalog

// Stupidly large data
https://github.com/aumcode/nfx/tree/master/Source/NFX/ApplicationModel/Pile
https://www.youtube.com/watch?v=eqWsWsj82u4&feature=youtu.be

// List<T> source code
https://referencesource.microsoft.com/#mscorlib/system/collections/generic/list.cs
 */