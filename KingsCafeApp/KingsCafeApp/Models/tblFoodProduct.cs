using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingsCafeApp.Models
{
    public class tblFoodProduct
    {
        [PrimaryKey, AutoIncrement]
        public int FOOD_PRODUCT_ID { get; set; }
        public string FOOD_PRODUCT_NAME { get; set; }
        public decimal FOOD_PRODUCT_PRICE { get; set; }
        public string FOOD_PRODUCT_PICTURE { get; set; }
        
        public int Quantity { get; set; }
        public int FOOD_CATEGORIES_FID { get; set; }

    }
}
