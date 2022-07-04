using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingsCafeApp.Models
{
    class tblFoodCategory
    {
        [PrimaryKey, AutoIncrement]
        public int FOOD_CATEGORIES_ID { get; set; }
        public string FOOD_CATEGORIES_NAME { get; set; }
        public string FOOD_CATEGORIES_PICTURE { get; set; }
        public int tblFoodProductsFID { get; set; }

    }
}