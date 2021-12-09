using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Globalization;
using System.Net.Http;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashBoardPage : ContentPage
    {
        public DashBoardPage()
        {
            InitializeComponent();
            double ad = 300000;
            List < Item > item = new List<Item>();
            for(var i = 0; i< 10; i++)
            {
                item.Add(new Item { Id = "1", Description = "Thuốc trừ sâu", Name = "Thuốc trừ sâu", Image = "anhthuoc.jpg", Price = 1000000 });
            }    
               
            LskItems.ItemsSource = item;
          
        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            var result = await httpClient.GetStringAsync("http://172.19.48.1/WebApplication2/api/ServiceController/HelloAPI");
            button.Text = result;
            

        }
    }
}