using SqliteApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqliteAppUnitTestUtils
{
    public static class AsyncToSync
    {
        public static void ClearBooksTable(BookEntryViewModel bevm)
        {
            bevm.ClearBooksTableAsync().Wait();
        }

        public static string ShowBooksTableStatus(BookEntryViewModel bevm)
        {
            return bevm.ShowBooksTableStatusAsync().Result;
        }
    }
}
