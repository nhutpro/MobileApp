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
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using Xamarin.Forms.PlatformConfiguration;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashBoardPage : ContentPage
    {
        public DashBoardPage()
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

       async private void ImageButton_Clicked(object sender, EventArgs e)
        {   ImageButton button = (ImageButton)sender;
            Products product = button.CommandParameter as Products;
            HttpClient httpClient = new HttpClient();
            String addCart = await httpClient.GetStringAsync($"{App.Localhost}/product/addcart?UserID=" + App.UserID +"&ProID=" + product.PRODUCTID); 
            await DisplayAlert("Thông Báo", "Thêm thành công", "OK");
            
        }

       async private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            resetColor();
            HttpClient httpClient = new HttpClient();
            var productlist = await httpClient.GetStringAsync($"{App.Localhost}/hello");
            var productlistConvert = JsonConvert.DeserializeObject<List<Products>>(productlist);
            LskItems.ItemsSource = productlistConvert.Where(c => Regex.Match(c.NAME, $"^{Search.Text}").Success);
        }

       async private void Button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            resetColor();
            button.BackgroundColor = Color.FromHex("008000");
            HttpClient httpClient = new HttpClient();
            var productlist = await httpClient.GetStringAsync($"{App.Localhost}/product/kemchongnang");
            var productlistConvert = JsonConvert.DeserializeObject<List<Products>>(productlist);
            LskItems.ItemsSource = productlistConvert;
        }
        public void resetColor()
        {
            suaRuaMat.BackgroundColor= kemChongNang.BackgroundColor = serum.BackgroundColor = Toner.BackgroundColor = Color.FromHex("306E51");
            
        }

       async  private void serum_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            resetColor();
            button.BackgroundColor = Color.FromHex("008000");
            HttpClient httpClient = new HttpClient();
            var productlist = await httpClient.GetStringAsync($"{App.Localhost}/product/serum");
            var productlistConvert = JsonConvert.DeserializeObject<List<Products>>(productlist);
            LskItems.ItemsSource = productlistConvert;
        }

        async private void Toner_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            resetColor();
            button.BackgroundColor = Color.FromHex("008000");
            HttpClient httpClient = new HttpClient();
            var productlist = await httpClient.GetStringAsync($"{App.Localhost}/product/toner");
            var productlistConvert = JsonConvert.DeserializeObject<List<Products>>(productlist);
            LskItems.ItemsSource = productlistConvert;
        }

        async  private void kemChongNang_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            resetColor();
            button.BackgroundColor = Color.FromHex("008000");
            HttpClient httpClient = new HttpClient();
            var productlist = await httpClient.GetStringAsync($"{App.Localhost}/product/kemchongnang");
            var productlistConvert = JsonConvert.DeserializeObject<List<Products>>(productlist);
            LskItems.ItemsSource = productlistConvert;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            resetColor();
            LisInit();
            
        }
    }
}