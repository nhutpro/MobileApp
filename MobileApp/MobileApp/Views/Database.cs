using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MobileApp.Views
{
    class Database
    {

        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        public bool CreateDatabase()
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "database.db");
                var connection = new SQLiteConnection(path);

                connection.CreateTable<User>();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddNewUser(User user)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "database.db");
                var connection = new SQLiteConnection(path);

                connection.Insert(user);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<User> GetUser()
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "database.db");
                var connection = new SQLiteConnection(path);

                return connection.Table<User>().ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}
