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
    public partial class CategoryDetails : ContentPage
    {
        public CategoryDetails(tblFoodCategory c)
        {
            InitializeComponent();
            LoadingInd.IsRunning = true;
            FOOD_CATEGORIES_NAME.Text = c.FOOD_CATEGORIES_NAME;
            FOOD_CATEGORIES_PICTURE.Source = c.FOOD_CATEGORIES_PICTURE;
            LoadingInd.IsRunning = false;
        }
    }
}