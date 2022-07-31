using Firebase.Database.Query;
using KingsCafeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KingsCafeApp.LoginSystem
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Userlist : ContentPage
    {
        public Userlist()
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
            DataList.ItemsSource = (await App.firebaseDatabase.Child("Users").OnceAsync<Users>()).Select(x => new Users
            {
                Userid = x.Object.Userid,
                Name = x.Object.Name,
                Email = x.Object.Email,
                Password = x.Object.Password,
                PhoneNo = x.Object.PhoneNo,
                Picture=x.Object.Picture
            }).ToList();
        }


        private async void DataList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {

                var selected = e.Item as Users;
                var item = (await App.firebaseDatabase.Child("Users").OnceAsync<Users>()).FirstOrDefault(a => a.Object.Userid == selected.Userid);
                var choice = await DisplayActionSheet("Options", "Close", "Delete", "View", "Edit");

                if (choice == "View")
                {
                    await DisplayAlert("Details",
                        "\n User Id: " + item.Object.Userid +
                        "\n Name: " + item.Object.Name +
                        "\n Email: " + item.Object.Email +
                        "\n Phone: " + item.Object.PhoneNo +
                        "\n Password: ******" +
                       "", "Ok");
                }
                if (choice == "Delete")
                {
                    var q = await DisplayAlert("Confirmation", "Are you sure you want to delete " + item.Object.Name + "?", "Yes", "No");
                    if (q)
                    {
                        await App.firebaseDatabase.Child("Users").Child(item.Key).DeleteAsync();
                        LoadData();
                        await DisplayAlert("Message", item.Object.Name + "'s" + " Account is deleted permanently.", "Ok");
                    }

                }
                if (choice == "Edit")
                {

                }

            }

            catch (Exception ex)
            {

                LoadingInd.IsRunning = false;
                await DisplayAlert("Error", "Something went wrong, please try again later. \nError: " + ex.Message, "Ok");
            }

        }
    }
}