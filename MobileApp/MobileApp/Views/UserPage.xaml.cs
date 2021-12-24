using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        public UserPage()
        {
            InitializeComponent();
            FullName.Text = SigninPage.currentUser.FullName;
            UsernName.Text = SigninPage.currentUser.UserName;

        }

        private void Infobtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChangeInfoPage());
        }

        private void SignoutBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new SigninPage());
           
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OrderPage());
        }
    }
}