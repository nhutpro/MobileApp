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
        public SignupPage()
        {
            InitializeComponent();
            initUsers();
        }
        async void initUsers()
        {
            HttpClient http = new HttpClient();
            string UsersList = await http.GetStringAsync("http://192.168.0.102/WebAPI/api/ServiceController/GetUser");
            users = JsonConvert.DeserializeObject<List<User>>(UsersList);
        }
        /*async void addUsers(string username, string password, string fullname, string email, string phone, string gender, string birthday, string role)
        {
            HttpClient http = new HttpClient();
            string UsersList = await http.GetStringAsync("http://192.168.0.102/WebAPI/api/ServiceController/AddUser?username={" + username + "}&password={" + password + "}&fullname={" + fullname + "}&email={" + email + "}&phone={" + phone + "}&gender={" + gender + "}&birthday={" + birthday + "}&role={" + role + "}");
        }*/
        async void RegisterBtn_Clicked(object sender, EventArgs e)
        {
            foreach (User user in users)
            {
                if (UserName.Text == user.UserName)
                {
                    await DisplayAlert("Thong bao", "Tên tài khoản đã tồn tại!!!", "OK");
                    return;
                }
            }
            HttpClient http = new HttpClient();
            var send = await http.GetStringAsync("http://192.168.0.102/WebAPI/api/ServiceController/AddUser?username=" + UserName.Text + "&password=" + PassWord.Text + "&fullname=" + FullName.Text + "&email=" + Email.Text + "&phone=" + Phone.Text + "&gender=Nam&birthday=" + DateofBirth.Text + "&role=User");
            
            await DisplayAlert("Thong bao", "Tao tai khoan thanh cong!!!", "OK");

        }

        private void LogginBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SigninPage());
        }
    }
}