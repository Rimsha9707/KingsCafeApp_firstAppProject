using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingsCafeApp.Models
{
     class tblAdmin
    {

        [PrimaryKey, AutoIncrement]
        public int ADMIN_ID { get; set; }
        public string ADMIN_NAME { get; set; }
        public string ADMIN_EMAIL { get; set; }
        public string ADMIN_PASSWORD { get; set; }
        public string ADMIN_CONTACT { get; set; }
        public string ADMIN_ADDRESS { get; set; }
        public string ADMIN_PICTURE { get; set; }
        public int tblOrderPurchases { get; set; }
    }
}
