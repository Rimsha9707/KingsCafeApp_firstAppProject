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
            try
            {
                DataList.ItemsSource = App.db.Table<Users>().ToList();
            }
            catch (Exception ex)
            {

                DisplayAlert("Error", "Something went wrong, please try again later. \nError: " + ex.Message, "Ok");
            }
        }

        private async void DataList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as Users;

            var choice = await DisplayActionSheet("Options", "Close", "Delete", "View", "Edit");

            if (choice == "View")
            {
                await DisplayAlert("Details",
                    "\n User Id: " + item.Userid +
                    "\n Name: " + item.Name +
                    "\n Email: " + item.Email +
                    "\n Phone: " + item.PhoneNo +
                    "\n Password: ******" +
                   "", "Ok");
            }
            if (choice == "Delete")
            {
                var q = await DisplayAlert("Confirmation", "Are you sure you want to delete "+ item.Name+"?", "Yes", "No");
                if (q)
                {
                    App.db.Delete(item);
                    DataList.ItemsSource = App.db.Table<Users>().ToList();
                    await DisplayAlert("Message",item.Name+"'s"+ " Account is deleted permanently.", "Ok");
                }
               
            }
            if (choice == "Edit")
            {

            }
            
        }
    }
}