using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MobileApp.Models;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderPage : ContentPage
    {
        public OrderPage()
        {
            InitializeComponent();
            
            
        }
       async public void listinit()
        {
            
            HttpClient httpClient = new HttpClient();
            var productlist = await httpClient.GetStringAsync($"{App.Localhost}/order/all?UserID={App.UserID}");
            var productlistConvert = JsonConvert.DeserializeObject<List<Orders>>(productlist);
            LskOrders.ItemsSource = productlistConvert;
     

        }

       async private void running_Clicked(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            var productlist = await httpClient.GetStringAsync($"{App.Localhost}/order/running?UserID={App.UserID}");
            
            var productlistConvert = JsonConvert.DeserializeObject<List<Orders>>(productlist);
            LskOrders.ItemsSource = productlistConvert;
            
        }

        async private void success_Clicked(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            var productlist = await httpClient.GetStringAsync($"{App.Localhost}/order/success?UserID={App.UserID}");
            var productlistConvert = JsonConvert.DeserializeObject<List<Orders>>(productlist);
            LskOrders.ItemsSource = productlistConvert;
        }

        async private void fail_Clicked(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            var productlist = await httpClient.GetStringAsync($"{App.Localhost}/order/fail?UserID={App.UserID}");
            var productlistConvert = JsonConvert.DeserializeObject<List<Orders>>(productlist);
            LskOrders.ItemsSource = productlistConvert;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            listinit();
        }
    }
}