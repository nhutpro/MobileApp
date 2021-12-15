﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class SigninPage : ContentPage
    {
        public static User currentUser;
        public SigninPage()
        {
            InitializeComponent();
        }

        private void RegisterBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignupPage());
        }

        private void LogginBtn_Clicked(object sender, EventArgs e)
        {
            List<User> users = new List<User>();
            
            Database db = new Database();
            users = db.GetUser();

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