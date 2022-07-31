using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingsCafeApp.Models
{
    class tblOrderPurchaseDetail
    {
        [PrimaryKey, AutoIncrement]
        public int ORDER_PURCHASE_DETAIL_ID { get; set; }

        public decimal ORDER_PURCHASE_DETAIL_QUANTITY { get; set; }

        public int ORDER_PURCHASE_FID { get; set; }

        public decimal ORDER_PURCHASE_DETAIL_PRICE { get; set; }

        public int INGREDIENT_FID { get; set; }

    }
}
