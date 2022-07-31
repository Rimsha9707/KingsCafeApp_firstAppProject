using Firebase.Database;
using Firebase.Storage;
using KingsCafeApp.Login;
using KingsCafeApp.Services;
using KingsCafeApp.Views;
using KingsCafeApp.Views.Admin;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KingsCafeApp
{
    public partial class App : Application
    {
        public static string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "dbKingsCafeApp.db3");
        public static SQLiteConnection db = new SQLiteConnection(dbPath);

        //Firebase Connections  ======================================
        public static FirebaseStorage FirebaseStorage = new FirebaseStorage("kings-cafe-app.appspot.com");

        public static FirebaseClient firebaseDatabase = new FirebaseClient("https://kings-cafe-app-default-rtdb.firebaseio.com/");


        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new Manage_Product();
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
