using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingsCafeApp.Models
{
    class tblOrder
    {
        [PrimaryKey, AutoIncrement]
        public int ORDER_ID { get; set; }
        public string ORDER_CUSTOMER_NAME { get; set; }
        public string ORDER_CUSTOMER_ADDRESS { get; set; }
        public string ORDER_CUSTOMER_CONTACT { get; set; }
        public string ORDER_STATUS { get; set; }
        public DateTime ORDER_DATE { get; set; }
        public string ORDER_PAYMENT { get; set; }
    }
}
