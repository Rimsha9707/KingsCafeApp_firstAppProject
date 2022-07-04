using KingsCafeApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace KingsCafeApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}