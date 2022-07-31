using Firebase.Database.Query;
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
    public partial class Edit_Category : ContentPage
    {

        private MediaFile _mediaFile;
        public static string PicPath= "category_picker.png";
        public static tblFoodCategory Cat= null;
        public static bool IsNewPicSelected= false;
        public Edit_Category(tblFoodCategory c)
        {
            InitializeComponent();

            Cat = c;
            txtCatName.Text = c.FOOD_CATEGORIES_NAME;
            PreviewPic.Source = c.FOOD_CATEGORIES_PICTURE;
           
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

                    _mediaFile = SelectedImg;
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

                    _mediaFile = SelectedImg;
                    PicPath = SelectedImg.Path;
                    PreviewPic.Source = SelectedImg.Path;


                }

                IsNewPicSelected = true;
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

                LoadingInd.IsRunning = true;

                string img = Cat.FOOD_CATEGORIES_PICTURE;
             
                if (IsNewPicSelected==true)
                {
                    var StoredImageURL = await App.FirebaseStorage
                    .Child("FOOD_CATEGORIES_PICTURE")
                    .Child(Cat.FOOD_CATEGORIES_ID.ToString() + "_" + txtCatName.Text + ".jpg")
                    .PutAsync(_mediaFile.GetStream());

                    img = StoredImageURL;

                }


                var OldCat = (await App.firebaseDatabase.Child("tblFoodCategory").OnceAsync<tblFoodCategory>()).FirstOrDefault(x => x.Object.FOOD_CATEGORIES_ID == Cat.FOOD_CATEGORIES_ID);


                OldCat.Object.FOOD_CATEGORIES_ID = Cat.FOOD_CATEGORIES_ID;
                OldCat.Object.FOOD_CATEGORIES_NAME = txtCatName.Text;
                OldCat.Object.FOOD_CATEGORIES_PICTURE = img;
     

                await App.firebaseDatabase.Child("tblFoodCategory").Child(OldCat.Key).PutAsync(OldCat.Object);
                LoadingInd.IsRunning = false;
                await DisplayAlert("Success", "Category Updated successfully", "Ok");
                await Navigation.PopAsync();

            }
            catch (Exception ex)
            {
                LoadingInd.IsRunning = false;
                await DisplayAlert("Error", "Something went wrong, please try again later. \nError: " + ex.Message, "Ok");
            }
        }

    }
}