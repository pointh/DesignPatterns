using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using System.Diagnostics;
using SqliteApp.Database;
using SQLite;
using SqliteApp.Models;
using System.Threading.Tasks;

namespace SqliteApp.ViewModels
{

    public class BookEntryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Command SaveCommand { get; set; }
        public Command ShowBooksCommand { get; set; }


        public BookEntryViewModel()
        {
            SaveCommand = new Command(SaveCurrentBook);
            ShowBooksCommand = new Command(ShowBooks);
        }

        public async void SaveCurrentBook()
        {
            var book = new Book { Price = Price, Title = Title };
            _ = await InsertBooksTable(book);
        }

        public async Task<int> InsertBooksTable(Book b)
        {
            SQLiteAsyncConnection db = SqliteBooks.GetInstance;
            int i = await db.InsertAsync(b);
            return i;
        }

        public async Task ClearBooksTable()
        {
            SQLiteAsyncConnection db = SqliteBooks.GetInstance;
            _ = await db.Table<Book>().DeleteAsync();
        }

        public async Task<string> ShowBooksTableStatus()
        {
            StringBuilder sb = new StringBuilder();

            SQLiteAsyncConnection db = SqliteBooks.GetInstance;
            var lb = await db.Table<Book>().ToListAsync();
            foreach (var b in lb)
                sb.Append(b + "\n");
            
            return sb.ToString();
        }

        public async void ShowBooks()
        {
            string s = await ShowBooksTableStatus();
            Debug.WriteLine(s);
        }

        private string title;
        public string Title
        {
            get => title;
            set
            {
                title = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Title"));
            }
        }

        private decimal price;
        public decimal Price
        {
            get => price;
            set
            {
                price = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Price"));
            }
        }

    }
}
