using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingsCafeApp.Models
{
    class tblOrderPurchase
    {

        [PrimaryKey, AutoIncrement]
        public int ORDER_PURCHASE_ID { get; set; }

        public DateTime ORDER_PURCHASE_DATE_TIME { get; set; }

        public int ADMIN_FID { get; set; }

        public virtual tblAdmin tblAdmin { get; set; }

        public int tblWorker_FID { get; set; }

    }
}
