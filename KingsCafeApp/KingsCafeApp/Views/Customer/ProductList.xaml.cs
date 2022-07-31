using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KingsCafeApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KingsCafeApp.Views.Customer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductList : ContentPage
    {
        public ProductList()
        {
            InitializeComponent();

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                LoadingInd.IsRunning = true;
                LoadData();
                LoadingInd.IsRunning = false;
            }
            catch (Exception ex)
            {
                LoadingInd.IsRunning = false;
                await DisplayAlert("Error", "Something went wrong, please try again later. \nError: " + ex.Message, "Ok");
            }
        }


        async void LoadData()
        {
            DataList.ItemsSource = (await App.firebaseDatabase.Child("tblFoodProduct").OnceAsync<tblFoodProduct>()).Select(x => new tblFoodProduct
            {
                FOOD_PRODUCT_ID = x.Object.FOOD_PRODUCT_ID,
                FOOD_PRODUCT_NAME = x.Object.FOOD_PRODUCT_NAME,
                FOOD_PRODUCT_PICTURE = x.Object.FOOD_PRODUCT_PICTURE,
                FOOD_PRODUCT_PRICE = x.Object.FOOD_PRODUCT_PRICE,
            }).ToList();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new StartPage();
        }

        private void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {

        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {

        }

        private void DataList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             
        }

        private void ToolbarItem_Clicked_2(object sender, EventArgs e)
        {

        }
    }
}