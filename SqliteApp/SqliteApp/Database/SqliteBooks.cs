using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SqliteApp.Models;
using SQLite;
using System.Diagnostics;

namespace SqliteApp.Database
{ 
    public class SqliteBooks
    {
        static SQLiteAsyncConnection instance;

        private SqliteBooks()
        {
        }

        public static SQLiteAsyncConnection GetInstance
        {
            get
            {
                if (instance == null)
                {
                    var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyBooks.db");
                    instance = new SQLiteAsyncConnection(databasePath);
                    instance.CreateTableAsync<Book>();
                    Debug.WriteLine("SqliteBooks connection created.");
                }

                Debug.WriteLine("SqliteBooks connection link provided.");
                return instance;
            }
        }
       
    }
}
