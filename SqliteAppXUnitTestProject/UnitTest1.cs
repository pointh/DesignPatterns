using System;
using Xunit;
using SqliteApp.ViewModels;
using System.Threading.Tasks;

namespace SqliteAppXUnitTestProject
{
    public class UnitTest1
    {
        [Fact]
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
            Assert.True(s.IndexOf(bookName) != -1);
        }
    }
}
