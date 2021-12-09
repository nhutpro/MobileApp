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
    public partial class SignupPage : ContentPage
    {
        public SignupPage()
        {
            InitializeComponent();
        }

        private void RegisterBtn_Clicked(object sender, EventArgs e)
        {
            Database db = new Database();

            List<User> users = new List<User>();
            users = db.GetUser();

            User newUser = new User();
            newUser.UserFullName = FullName.Text;
            newUser.UserName = UserName.Text;
            newUser.Password = PassWord.Text;
            newUser.UserGender = "Nam";
            newUser.UserDoB = DateofBirth.Text;

            foreach (User user in users)
            {
                if (UserName.Text == user.UserName)
                {
                    DisplayAlert("Thong bao", "Email/SDT da ton tai!!!", "OK");
                    return;
                }
            }
            if (db.AddNewUser(newUser))
            {
                DisplayAlert("Thong bao", "Tao tai khoan thanh cong!!!", "OK");
            }
            else
            {
                DisplayAlert("Canh bao", "Tao tai khoan that bai!!!", "OK");
            }
        }

        private void LogginBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SigninPage());
        }
    }
}