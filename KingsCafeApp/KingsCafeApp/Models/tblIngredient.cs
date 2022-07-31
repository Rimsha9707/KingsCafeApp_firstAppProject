using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingsCafeApp.Models
{
    class tblIngredient
    {
        [PrimaryKey, AutoIncrement]
        public int INGREDIENT_ID { get; set; }

        public string INGREDIENT_NAME { get; set; }
        public decimal INGREDIENT_PRICE { get; set; } 

        public int Quantity { get; set; }

        public decimal INGREDIENT_UNIT_PRICE { get; set; }

    }
}
