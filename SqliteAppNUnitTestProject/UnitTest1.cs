using NUnit.Framework;
using SqliteApp.ViewModels;
using System.Threading.Tasks;

namespace SqliteAppNUnitTestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
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