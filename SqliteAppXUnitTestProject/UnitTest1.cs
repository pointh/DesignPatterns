using System;
using Xunit;
using SqliteApp.ViewModels;
using System.Threading.Tasks;
using SqliteAppUnitTestUtils;

namespace SqliteAppXUnitTestProject
{
    public class UnitTest1
    {
        //[Fact]
        //public async Task Test1()
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
        //    Assert.True(s.IndexOf(bookName) != -1);
        //}

        [Fact]
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
            Assert.True(s.IndexOf(bookName) != -1);
        }
    }
}
