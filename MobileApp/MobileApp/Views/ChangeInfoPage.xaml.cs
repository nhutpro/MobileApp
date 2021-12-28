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
    public partial class ChangeInfoPage : ContentPage
    {
        string usergender;
        public ChangeInfoPage()
        {
            InitializeComponent();
            GetCurrentUsers();
            Gender.Items.Add("Nam");
            Gender.Items.Add("Nữ");
            UserName.Text = SigninPage.currentUser.UserName;
            FullName.Text = SigninPage.currentUser.FullName;
            Email.Text = SigninPage.currentUser.Email;
            Phone.Text = SigninPage.currentUser.Phone;
            Address.Text = SigninPage.currentUser.Address;
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
        }

        async void ChangeBtn_Clicked(object sender, EventArgs e)
        {
            User user = SigninPage.currentUser;
            user.UserName = FullName.Text;


            HttpClient http = new HttpClient();
            var send = await http.GetStringAsync($"{App.Localhost}/api/ServiceController/ChangeUserInfo?userid=" + SigninPage.currentUser.UserID + "&fullname=" + FullName.Text + "&email=" + Email.Text + "&phone=" + Phone.Text + "&gender=" + Gender + "&birthday=" + Date.Date + "&address=" + Address.Text + "");


            await Navigation.PushAsync(new UserPage());
        }

        private void Gender_SelectedIndexChanged(object sender, EventArgs e)
        {
            usergender = Gender.Items[Gender.SelectedIndex];
        }
    }
}