using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLite;
using SqliteApp.Database;
using SqliteApp.Models;
using SqliteApp.ViewModels;

namespace SqliteAppUnitTest
{
    [TestClass]
    public class UnitTestBookEntryViewModel
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            string bookName = "Hájili jsme hrad";
            BookEntryViewModel bevm = new BookEntryViewModel();
            _ = bevm.ClearBooksTable();
            bevm.Price = 100.0m;
            bevm.Title = bookName;

            // Act
            bevm.SaveCommand.Execute(null);

            // Assert
            SQLiteAsyncConnection db = SqliteBooks.GetInstance;
            string s = bevm.ShowBooksTableStatus().Result;
            Assert.IsTrue(s.IndexOf(bookName) != -1);
        }
    }
}
