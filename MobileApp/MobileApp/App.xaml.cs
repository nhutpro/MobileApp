using MobileApp.Services;
using MobileApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp
{
    public partial class App : Application
    {
        public static int UserID { get; set; }
        public static string Localhost { get; set; }
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();


            Localhost = "http://192.168.1.11/MobileAPI";
            MainPage = new NavigationPage (new SigninPage());
          
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
