using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MobileApp.Views
{
    public class User
    {

        [PrimaryKey, AutoIncrement]
        public int UserID { get; set; }
        public string UserFullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserGender { get; set; }
        public string UserDoB { get; set; }
    }
}
