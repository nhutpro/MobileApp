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
        public ChangeInfoPage()
        {
            InitializeComponent();
            FullName.Text = SigninPage.currentUser.FullName;
            Email.Text = SigninPage.currentUser.Email;
            Phone.Text = SigninPage.currentUser.Phone;
            DateofBirth.Text = SigninPage.currentUser.Birthday;
            Gender.Text = SigninPage.currentUser.Gender;
        }

        async void ChangeBtn_Clicked(object sender, EventArgs e)
        {
            User user = SigninPage.currentUser;
            user.UserName = FullName.Text;
            user.Birthday = DateofBirth.Text;
            user.Gender = Gender.Text;

            HttpClient http = new HttpClient();
            var send = await http.GetStringAsync("http://192.168.1.8/MobileAPI/api/ServiceController/ChangeUserInfo?userid=" + SigninPage.currentUser.UserID + "&fullname=" + FullName.Text + "&email=" + Email.Text + "&phone=" + Phone.Text + "&gender=" + Gender.Text + "&birthday=" + DateofBirth.Text + "&address=" + Address.Text + "");


            await Navigation.PushAsync(new UserPage());
        }
    }
}