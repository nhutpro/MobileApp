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
    public partial class SignupPage : ContentPage
    {
        public List<User> users;
        string usergender;
        public SignupPage()
        {
            InitializeComponent();
            initUsers();
            Gender.Items.Add("Nam");
            Gender.Items.Add("Nữ");
        }
        async void initUsers()
        {
            HttpClient http = new HttpClient();
            string UsersList = await http.GetStringAsync($"{App.Localhost}/api/ServiceController/GetUser");
            users = JsonConvert.DeserializeObject<List<User>>(UsersList);
        }
        /*async void addUsers(string username, string password, string fullname, string email, string phone, string gender, string birthday, string role)
        {
            HttpClient http = new HttpClient();
            string UsersList = await http.GetStringAsync("http://192.168.1.8/MobileAPI/api/ServiceController/AddUser?username={" + username + "}&password={" + password + "}&fullname={" + fullname + "}&email={" + email + "}&phone={" + phone + "}&gender={" + gender + "}&birthday={" + birthday + "}&role={" + role + "}");
        }*/
        async void RegisterBtn_Clicked(object sender, EventArgs e)
        {
            foreach (User user in users)
            {
                if (UserName.Text == user.UserName)
                {
                    await DisplayAlert("Thông Báo", "Tên tài khoản đã tồn tại!!!", "OK");
                    return;
                }
            }

            HttpClient http = new HttpClient();
            var send = await http.GetStringAsync($"{App.Localhost}/api/ServiceController/AddUser?username=" + UserName.Text + "&password=" + PassWord.Text + "&fullname=" + FullName.Text + "&email=" + Email.Text + "&phone=" + Phone.Text + "&gender=Nam&birthday=" + Date.Date + "&role=User");
            
            await DisplayAlert("Thông Báo", "Tạo Tài Khoản Thành Công!!!", "OK");

        }

        private void LogginBtn_Clicked(object sender, EventArgs e)
        {
           
            Navigation.PushAsync(new SigninPage());
        }

        private void Gender_SelectedIndexChanged(object sender, EventArgs e)
        {
            usergender = Gender.Items[Gender.SelectedIndex];
        }
    }
}