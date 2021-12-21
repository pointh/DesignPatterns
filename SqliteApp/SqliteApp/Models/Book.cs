using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SqliteApp.Models
{
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Název: {Title}, Cena: {Price}";
        }
    }
}
