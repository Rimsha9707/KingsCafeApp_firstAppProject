using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingsCafeApp.Models
{
    class tblOrderDetail
    {
        [PrimaryKey, AutoIncrement]
        public int ORDER_DETAIL_ID { get; set; }

        public int ORDER_FID { get; set; }

        public int FOOD_PRODUCT_FID { get; set; }

        public decimal ORDER_DETAIL_QUANTITY { get; set; }

        public decimal ORDER_DETAIL_PRICE { get; set; }

        public bool ORDER_DETAIL_ISADDING { get; set; }

    }
}
