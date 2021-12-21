using Microsoft.VisualStudio.TestTools.UnitTesting;

using SQLite;
using SqliteApp.Database;
using SqliteApp.Models;
using SqliteApp.ViewModels;
using System.Diagnostics;
using System;
using System.Threading.Tasks;

namespace SqliteAppUnitTest
{
    [TestClass]
    public class UnitTestBookEntryViewModel
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            // Arrange
            string bookName = "Hájili jsme hrad";
            BookEntryViewModel bevm = new BookEntryViewModel();
            bevm.ClearBooksTable();
            bevm.Price = 100.0m;
            bevm.Title = bookName;
            
            // Act
            bevm.SaveCommand.Execute(null);

            // Assert
            string s = await bevm.ShowBooksTableStatus();
            Assert.IsTrue(s.IndexOf(bookName) != -1);
        }
    }
}
