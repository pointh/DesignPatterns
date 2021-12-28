using Microsoft.VisualStudio.TestTools.UnitTesting;

using SQLite;
using SqliteApp.Database;
using SqliteApp.Models;
using SqliteApp.ViewModels;
using System.Diagnostics;
using System;
using System.Threading.Tasks;
using SqliteAppUnitTestUtils;

namespace SqliteAppUnitTest
{
    [TestClass]
    public class UnitTestBookEntryViewModel
    {
        //[TestMethod]
        //public async Task TestMethod1()
        //{
        //    // Arrange
        //    string bookName = "Hájili jsme hrad";
        //    BookEntryViewModel bevm = new BookEntryViewModel();
        //    await bevm.ClearBooksTableAsync();
        //    bevm.Price = 100.0m;
        //    bevm.Title = bookName;
            
        //    // Act
        //    bevm.SaveCommand.Execute(null);

        //    // Assert
        //    string s = await bevm.ShowBooksTableStatusAsync();
        //    Assert.IsTrue(s.IndexOf(bookName) != -1);
        //}

        [TestMethod]
        public void TestSync()
        {
            // Arrange
            string bookName = "Hájili jsme hrad";
            BookEntryViewModel bevm = new BookEntryViewModel();
            AsyncToSync.ClearBooksTable(bevm);
            bevm.Price = 100.0m;
            bevm.Title = bookName;

            // Act
            bevm.SaveCommand.Execute(null);

            // Assert
            string s = AsyncToSync.ShowBooksTableStatus(bevm);
            Assert.IsTrue(s.IndexOf(bookName) != -1);
        }
    }
}
