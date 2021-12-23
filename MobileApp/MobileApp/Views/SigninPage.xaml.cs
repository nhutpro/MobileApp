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
    
    public partial class SigninPage : ContentPage
    {
        public static User currentUser;
        public List<User> users;
        public SigninPage()
        {
            InitializeComponent();
            initUsers();
        }

        private void RegisterBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignupPage());
        }
        async void initUsers()
        {
            HttpClient http = new HttpClient();
            string UsersList = await http.GetStringAsync("http://192.168.0.102/WebAPI/api/ServiceController/GetUser");
            users = JsonConvert.DeserializeObject<List<User>>(UsersList);
        }

        private void LogginBtn_Clicked(object sender, EventArgs e)
        {

            if (UserName.Text != null && Password.Text != null)
            {
                foreach (User user in users)
                {
                    if (user.UserName == UserName.Text && user.Password == Password.Text)
                    {
                        currentUser = user;
                        DisplayAlert("Thong bao", "Dang nhap thanh cong!!!", "OK");
                        App.Current.MainPage = new AppShell();

                    }
                }
            }
            else
            {
                DisplayAlert("Thong bao", "Nhap tai khoan va mat khau!!!", "OK");
            }
            
        }

        private void FogotPass_Clicked(object sender, EventArgs e)
        {

        }
    }
}