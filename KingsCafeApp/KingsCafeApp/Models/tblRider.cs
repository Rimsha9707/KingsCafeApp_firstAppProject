using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingsCafeApp.Models
{
    class tblRider
    {

        [PrimaryKey, AutoIncrement]
        public int RIDER_ID { get; set; }
        public string RIDER_NAME { get; set; }
        public string RIDER_EMAIL { get; set; }
        public string RIDER_PASSWORD { get; set; }
        public string RIDER_CONTACT { get; set; }
        public string RIDER_ADDRESS { get; set; }
        public string RIDER_LOCATION { get; set; }

        
    }
}
