using MobileApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        List<Product> products = new List<Product>();

        async void init()
        {
            HttpClient http = new HttpClient();

            string ProductsList = await http.GetStringAsync($"{App.Localhost}/product/GetProductsByPriceDesc");
            List<Products> featuredListConverted = JsonConvert.DeserializeObject<List<Products>>(ProductsList);

            ProductsList = await http.GetStringAsync($"{App.Localhost}/product/GetProductsByPriceAsc");
            List<Products> ascListConverted = JsonConvert.DeserializeObject<List<Products>>(ProductsList);

            featureList.ItemsSource = featuredListConverted;
            asclist.ItemsSource = ascListConverted;
        }

        public HomePage()
        {
            InitializeComponent();
            init();
        }
        private void featureList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Products p = (Products)e.SelectedItem;
            Navigation.PushAsync(new ProductPage(p));
        }
    }
}