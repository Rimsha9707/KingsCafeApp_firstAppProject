using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingsCafeApp.Models
{
    class Users
    {
        [PrimaryKey, AutoIncrement]
        public int Userid { get; set; }
        public String Name { get; set; }
        public String PhoneNo { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
    }
}
