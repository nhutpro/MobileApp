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
          
            NavigationPage.SetHasBackButton(this, false);
        }

        private void RegisterBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignupPage());
        }
        async void initUsers()
        {
            HttpClient http = new HttpClient();
            string UsersList = await http.GetStringAsync($"{App.Localhost}/api/ServiceController/GetUser");
            users = JsonConvert.DeserializeObject<List<User>>(UsersList);
        }

        private void LogginBtn_Clicked(object sender, EventArgs e)
        {
            int sum = 0;
            if (UserName.Text != null && Password.Text != null)
            {
                foreach (User user in users)
                {
                    if (user.UserName == UserName.Text && user.Password == Password.Text)
                    {
                        sum = 1;
                        currentUser = user;
                        DisplayAlert("Thông Báo", "Đăng nhập thành công!!!", "OK");
                        if (user.Role == "admin")
                        {   
                            App.Current.MainPage = new AdminPage();
                            App.UserID = user.UserID;
                            currentUser = user;
                        }
                        else
                        {
                            App.Current.MainPage = new AppShell();
                            App.UserID = user.UserID;
                            currentUser = user;
                        }    
                            
                    }
                }
                if(sum == 0)
                {
                    DisplayAlert("Thông Báo", "Mật khẩu không đúng", "OK");
                }    
            }
            else
            {
                DisplayAlert("Thông Báo", "Nhập tài khoản và mật khẩu!!!", "OK");
            }
            
        }

        private void FogotPass_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChangePasswordPage());
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            initUsers();


        }
    }
}