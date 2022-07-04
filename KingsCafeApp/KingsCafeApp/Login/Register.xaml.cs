using KingsCafeApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KingsCafeApp.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {


        public Register()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
           try
            {

              
                 if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtPhone.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
               await DisplayAlert("Error", "Please fill required fields and try again", "Ok");
                return;
            }

            if (txtPassword.Text != txtCPassword.Text)
            {
                await DisplayAlert("Error", "Passwords do not match", "Ok");
                return;
            }

            App.db.CreateTable<Users>();

            var check = App.db.Table<Users>().FirstOrDefault(x => x.Email == txtEmail.Text);

            if (check!= null)
            {
                    await DisplayAlert("Error", "This Email is already registered", "ok");
                    return;

            }

               Users u = new Users()
                {
                    Name = txtName.Text,
                    PhoneNo = txtPhone.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                };

                App.db.Insert(u);
                await DisplayAlert("Success", "Your Account is Registered successfully", "Ok");
                await Navigation.PushAsync(new loginUser());
                  
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Something went wrong, please try again later. \nError: " + ex.Message, "Ok");
            }
           
        }
    }
}