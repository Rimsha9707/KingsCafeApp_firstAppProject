using KingsCafeApp.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
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
    public partial class Add_Category : ContentPage
    {
        public static string PicPath= "category_picker.png";
        public Add_Category()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            try
            {
                var response = await DisplayActionSheet("Select Image Source", "Close", "", "From Gallery", "From Camera");
                if (response == "From Camera")
                {
                    await CrossMedia.Current.Initialize();
                    if (!CrossMedia.Current.IsTakePhotoSupported)
                    {
                        await DisplayAlert("Error", "Phone is not Take Photo Supported", "OK");
                        return;
                    }

                    var mediaOptions = new StoreCameraMediaOptions()
                    {
                        PhotoSize = PhotoSize.Medium
                    };

                    var SelectedImg = await CrossMedia.Current.TakePhotoAsync(mediaOptions);

                    if (SelectedImg == null)
                    {
                        await DisplayAlert("Error", "Error Taking Image...", "OK");
                        return;
                    }

                    PicPath = SelectedImg.Path;
                    PreviewPic.Source = SelectedImg.Path;


                }
                if (response == "From Gallery")
                {
                    await CrossMedia.Current.Initialize();
                    if (!CrossMedia.Current.IsPickPhotoSupported)
                    {
                        await DisplayAlert("Error", "Phone is not Pick Photo Supported", "OK");
                        return;
                    }

                    var mediaOptions = new PickMediaOptions()
                    {
                        PhotoSize = PhotoSize.Medium
                    };

                    var SelectedImg = await CrossMedia.Current.PickPhotoAsync(mediaOptions);

                    if (SelectedImg == null)
                    {
                        await DisplayAlert("Error", "Error Picking Image...", "OK");
                        return;
                    }

                    PicPath = SelectedImg.Path;
                    PreviewPic.Source = SelectedImg.Path;


                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Message", "Something Went wrong \n" + ex.Message, "OK");

            }
        }

        private async void btnCat_Clicked(object sender, EventArgs e)
        {
            try
            {


                if (string.IsNullOrEmpty(txtCatName.Text))
                {
                    await DisplayAlert("Error", "Please fill required fields and try again", "Ok");
                    return;
                }

               App.db.CreateTable<tblFoodCategory>();

                var check = App.db.Table<tblFoodCategory>().FirstOrDefault(x => x.FOOD_CATEGORIES_NAME == txtCatName.Text);

                if (check != null)
                {
                    await DisplayAlert("Error", "This Category is already added", "ok");
                    return;

                }

                tblFoodCategory c = new tblFoodCategory()
                {
                    FOOD_CATEGORIES_NAME = txtCatName.Text,
                    FOOD_CATEGORIES_PICTURE= PicPath
                };

                App.db.Insert(c);
                await DisplayAlert("Success", "Category is added successfully", "Ok");
              

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Something went wrong, please try again later. \nError: " + ex.Message, "Ok");
            }
        }
    }
}