using NUnit.Framework;
using SqliteApp.ViewModels;
using SqliteAppUnitTestUtils;
using System.Threading.Tasks;

namespace SqliteAppNUnitTestProject
{

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        //[Test]
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
        //    Assert.IsTrue(s.IndexOf(bookName) != -1);
        //}

        [Test]
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