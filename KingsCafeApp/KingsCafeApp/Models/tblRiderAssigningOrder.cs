using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingsCafeApp.Models
{
    class tblRiderAssigningOrder
    {
        [PrimaryKey, AutoIncrement]
        public int RIDER_ASSIGNING_ORDER_ID { get; set; }

        public int ORDER_FID { get; set; }

        public int RIDER_FID { get; set; }
    }
}
