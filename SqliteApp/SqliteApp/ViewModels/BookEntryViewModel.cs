using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using System.Diagnostics;
using System.Globalization;
using SqliteApp.Database;
using SQLite;
using SqliteApp.Models;
using System.Collections.Generic;

namespace SqliteApp.ViewModels
{
    public class DecimalStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((decimal)value).ToString();
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (((string)value)[((string)value).Length - 1] == '.')
                return value;

            if (decimal.TryParse((string)value, out decimal d))
            {
                return d;
            }
            else
                return value;
        }
    }

    class BookEntryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public BookEntryViewModel()
        {
            SaveCommand = new Command(async () =>
            {
                Debug.WriteLine(Title);
                Debug.WriteLine(Price);
                SQLiteAsyncConnection db = SqliteBooks.GetInstance;
                var book = new Book { Price = Price, Title = Title };
                int i = await db.InsertAsync(book);
                Debug.WriteLine($"Vloženo: {i} záznam do databáze knih");
                int k = await db.Table<Book>().CountAsync();
                Debug.WriteLine($"Tabulka má {k} záznamů");
                var lb = await db.Table<Book>().ToListAsync();
                foreach (var b in lb)
                    Debug.WriteLine(b);
            });
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

        public Command SaveCommand { get; set; }
    }
}
