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
    public partial class ManageCategory : ContentPage
    {
        public ManageCategory()
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
            DataList.ItemsSource = (await App.firebaseDatabase.Child("tblFoodCategory").OnceAsync<tblFoodCategory>()).Select(x => new tblFoodCategory
            {
                FOOD_CATEGORIES_ID = x.Object.FOOD_CATEGORIES_ID,
                FOOD_CATEGORIES_NAME = x.Object.FOOD_CATEGORIES_NAME,
                FOOD_CATEGORIES_PICTURE=x.Object.FOOD_CATEGORIES_PICTURE,
            }).ToList();
        }

       
        private async void DataList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {

                var selected = e.Item as tblFoodCategory;
                var item = (await App.firebaseDatabase.Child("tblFoodCategory").OnceAsync<tblFoodCategory>()).FirstOrDefault(a => a.Object.FOOD_CATEGORIES_ID == selected.FOOD_CATEGORIES_ID);
                var choice = await DisplayActionSheet("Options", "Close", "Delete", "View", "Edit");

                if (choice == "View")
                {
                    await Navigation.PushAsync(new CategoryDetails(selected));
                }
                if (choice == "Delete")
                {
                    var q = await DisplayAlert("Confirmation", "Are you sure you want to delete " + item.Object.FOOD_CATEGORIES_NAME + "?", "Yes", "No");
                    if (q)
                    {
                        await App.firebaseDatabase.Child("tblFoodCategory").Child(item.Key).DeleteAsync();
                        LoadData();
                        await DisplayAlert("Message", item.Object.FOOD_CATEGORIES_NAME + "'s" + " Category is deleted permanently.", "Ok");
                    }

                }
                if (choice == "Edit")
                {
                    await Navigation.PushAsync(new Edit_Category(selected));

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