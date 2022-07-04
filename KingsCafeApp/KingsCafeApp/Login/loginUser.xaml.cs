using KingsCafeApp.LoginSystem;
using KingsCafeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KingsCafeApp.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class loginUser : ContentPage
    {
        public loginUser()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                await DisplayAlert("Error", "Please fill required fields and try again", "Ok");
                return;
            }
            App.db.CreateTable<Users>();
            var check = App.db.Table<Users>().FirstOrDefault(x => x.Email == txtEmail.Text && x.Password == txtPassword.Text);

            if (check == null)
            {
                await DisplayAlert("Error", "Invalid Email or Password is incorrect", "ok");
                return;
            }
            else
            {
                await Navigation.PushAsync(new Userlist());
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }
    }
}