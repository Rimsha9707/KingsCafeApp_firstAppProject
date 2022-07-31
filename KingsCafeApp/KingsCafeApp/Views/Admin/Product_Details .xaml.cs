using KingsCafeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KingsCafeApp.Views.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Product_Details : ContentPage
    {
        public Product_Details(tblFoodProduct p)
        {
            InitializeComponent();
            LoadingInd.IsRunning = true;
            txtProName.Text = p.FOOD_PRODUCT_NAME;
            txtProImage.Source = p.FOOD_PRODUCT_PICTURE;
            txtProPrice.Text = p.FOOD_PRODUCT_PRICE.ToString();
            LoadingInd.IsRunning = false;
        }
    }
}