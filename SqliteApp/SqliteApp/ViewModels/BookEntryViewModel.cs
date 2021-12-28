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
            SaveCommand = new Command(SaveCurrentBookAsync);
            
            ShowBooksCommand = new Command(ShowBooksAsync);
        }

        public async void SaveCurrentBookAsync()
        {
            var book = new Book { Price = Price, Title = Title };
            int i = await InsertBooksTableAsync(book);
            Debug.WriteLine($"Uložil {i} knih.");
        }

        public async Task<int> InsertBooksTableAsync(Book b)
        {
            SQLiteAsyncConnection db = SqliteBooks.GetInstance;
            int i = await db.InsertAsync(b);
            return i;
        }

        public async Task ClearBooksTableAsync()
        {
            SQLiteAsyncConnection db = SqliteBooks.GetInstance;
            int k = await db.Table<Book>().DeleteAsync((t) => true);
            Debug.WriteLine($"Smazal {k} knih.");
        }

        public async Task<string> ShowBooksTableStatusAsync()
        {
            StringBuilder sb = new StringBuilder();

            SQLiteAsyncConnection db = SqliteBooks.GetInstance;
            var lb = await db.Table<Book>().ToListAsync();
            foreach (var b in lb)
                sb.Append(b + "\n");
            
            return sb.ToString();
        }

        public async void ShowBooksAsync()
        {
            string s = await ShowBooksTableStatusAsync();
            Debug.WriteLine(s);
        }

        private string title;
        public string Title
        {
            get => title;
            set
            {
                title = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Title"));
            }
        }

        private decimal price;
        public decimal Price
        {
            get => price;
            set
            {
                price = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Price"));
            }
        }

    }
}
