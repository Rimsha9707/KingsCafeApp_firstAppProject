using Firebase.Database.Query;
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
    public partial class Manage_Product : ContentPage
    {
        public Manage_Product()
        {
            InitializeComponent();

        }

        //OnAppearing is overrided fuction which we use here
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
                FOOD_PRODUCT_PICTURE=x.Object.FOOD_PRODUCT_PICTURE,
                FOOD_PRODUCT_PRICE=x.Object.FOOD_PRODUCT_PRICE,
            }).ToList();
        }

       
        private async void DataList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {

                var selected = e.Item as tblFoodProduct;
                var item = (await App.firebaseDatabase.Child("tblFoodProduct").OnceAsync<tblFoodProduct>()).FirstOrDefault(a => a.Object.FOOD_PRODUCT_ID == selected.FOOD_PRODUCT_ID);
                var choice = await DisplayActionSheet("Options", "Close", "Delete", "View", "Edit");

                if (choice == "View")
                {
                    await Navigation.PushAsync(new Product_Details(selected));
                }
                if (choice == "Delete")
                {
                    var q = await DisplayAlert("Confirmation", "Are you sure you want to delete " + item.Object.FOOD_PRODUCT_NAME + "?", "Yes", "No");
                    if (q)
                    {
                        await App.firebaseDatabase.Child("tblFoodProduct").Child(item.Key).DeleteAsync();
                        LoadData();
                        await DisplayAlert("Message", item.Object.FOOD_PRODUCT_NAME + "'s" + " Product is deleted permanently.", "Ok");
                    }

                }
                if (choice == "Edit")
                {
                    await Navigation.PushAsync(new Edit_Product(selected));

                }

            }

            catch (Exception ex)
            {

                LoadingInd.IsRunning = false;
                await DisplayAlert("Error", "Something went wrong, please try again later. \nError: " + ex.Message, "Ok");
            }

        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new StartPage();
        }
    }
}