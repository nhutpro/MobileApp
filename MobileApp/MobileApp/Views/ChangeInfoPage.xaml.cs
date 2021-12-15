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
    public partial class ChangeInfoPage : ContentPage
    {
        public ChangeInfoPage()
        {
            InitializeComponent();
        }

        private void ChangeBtn_Clicked(object sender, EventArgs e)
        {
            User user = SigninPage.currentUser;
            user.UserName = FullName.Text;
            user.UserDoB = DateofBirth.Text;
            user.UserGender = "Nam";
            Database db = new Database();
            db.ChangeUserInfo(user);
            Navigation.PushAsync(new UserPage());
        }
    }
}