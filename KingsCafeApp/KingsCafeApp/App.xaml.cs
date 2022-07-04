using KingsCafeApp.Login;
using KingsCafeApp.Services;
using KingsCafeApp.Views;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KingsCafeApp
{
    public partial class App : Application
    {
       public static string  dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "dbKingsCafeApp.db3");
       public static SQLiteConnection db = new SQLiteConnection(dbPath);

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new Views.Admin.Add_Category();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
