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
    public partial class ChangePasswordPage : ContentPage
    {
        public List<User> users;
        public ChangePasswordPage()
        {
            InitializeComponent();
            initUsers();
        }
        async void initUsers()
        {
            HttpClient http = new HttpClient();
            string UsersList = await http.GetStringAsync($"{App.Localhost}/api/ServiceController/GetUser");
            users = JsonConvert.DeserializeObject<List<User>>(UsersList);
        }
        async void ChangePassbtn_Clicked(object sender, EventArgs e)
        {
            int sum = 0;
            if (Email.Text != null && Password.Text != null && RePassword.Text != null)
            {
                foreach (User user in users)
                {
                    if (user.Email == Email.Text && RePassword.Text == Password.Text)
                    {
                      
                        HttpClient http = new HttpClient();
                        var send = await http.GetStringAsync($"{App.Localhost}/api/ServiceController/ChangeUserPassword?email=" + Email.Text + "&password=" + Password.Text + "");
                        await DisplayAlert("Thông báo", "Thay đổi mật khẩu thành công!", "OK");
                        sum = 1;
                        await Navigation.PopAsync();
                    }
                }
                if(sum == 0)
                {
                    await DisplayAlert("Thong bao", "Loi", "OK");
                }
            }
            else
            {
               await DisplayAlert("Thong bao", "Vui lòng nhập thông tin!", "OK");
            }
        }
    }
}