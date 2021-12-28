using SqliteApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqliteAppUnitTestUtils
{
    public class AsyncToSync
    {
        public static void ClearBooksTable(BookEntryViewModel bevm)
        {
            bevm.ClearBooksTableAsync().ConfigureAwait(true).GetAwaiter().
                GetResult();
        }

        public static string ShowBooksTableStatus(BookEntryViewModel bevm)
        {
            return bevm.ShowBooksTableStatusAsync().ConfigureAwait(true).
                GetAwaiter().GetResult();
        }
    }
}
