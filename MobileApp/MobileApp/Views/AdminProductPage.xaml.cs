using MobileApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminProductPage : ContentPage
    {
        public AdminProductPage()
        {
            InitializeComponent();
       
        }
        async void LisInit()
        {
            HttpClient httpClient = new HttpClient();
            var productlist = await httpClient.GetStringAsync($"{App.Localhost}/hello");
            var productlistConvert = JsonConvert.DeserializeObject<List<Products>>(productlist);
            LskItems.ItemsSource = productlistConvert;


        }

       async private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            var productlist = await httpClient.GetStringAsync($"{App.Localhost}/hello");
            var productlistConvert = JsonConvert.DeserializeObject<List<Products>>(productlist);
            LskItems.ItemsSource = productlistConvert.Where(c => Regex.Match(c.PRODUCTID, $"^{Search.Text}").Success);
        }

        private void LskItems_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Products p = (Products)e.SelectedItem;
            Navigation.PushAsync(new AdminProductDetailPage(p));
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            LisInit();



        }
    }
}