using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Newtonsoft.Json;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        public UserPage()
        {
            InitializeComponent();
            GetCurrentUsers();
        }
        async void GetCurrentUsers()
        {
            List<User> users = new List<User>();
            HttpClient http = new HttpClient();
            string UsersList = await http.GetStringAsync("http://192.168.0.102/WebAPI/api/ServiceController/GetUser");
            users = JsonConvert.DeserializeObject<List<User>>(UsersList);
            foreach (User user in users)
            {
                if (user.UserID == SigninPage.currentUser.UserID)
                {
                    SigninPage.currentUser = user;
                }
            }
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