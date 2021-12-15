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

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashBoardPage : ContentPage
    {
        public DashBoardPage()
        {
            InitializeComponent();

            LisInit();
          
        }
        async void LisInit()
        {
            HttpClient httpClient = new HttpClient();
            var productlist = await httpClient.GetStringAsync("http://172.18.128.1/MobileAPI/hello");
            var productlistConvert = JsonConvert.DeserializeObject<List<Products>>(productlist);
            LskItems.ItemsSource = productlistConvert;
           
           
        }

       async private void ImageButton_Clicked(object sender, EventArgs e)
        {   ImageButton button = (ImageButton)sender;
            Products product = button.CommandParameter as Products;
            HttpClient httpClient = new HttpClient();
            String addCart = await httpClient.GetStringAsync("http://172.18.128.1/MobileAPI/product/addcart?UserID=USE01&ProID="+product.PRODUCTID); 
            await DisplayAlert("Thông Báo", "Thêm thành công", "OK");
            
        }
    }
}