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
    public partial class StatusUpdatePage : ContentPage
    {
        public StatusUpdatePage()
        {
            InitializeComponent();
            listInit();
            
        }
       async public void listInit()
        {

            List<Orders> listOrder = new List<Orders>();
            HttpClient httpClient = new HttpClient();
            var productlist = await httpClient.GetStringAsync($"{App.Localhost}/order/running?UserID=" + App.UserID);
            var productlistConvert = JsonConvert.DeserializeObject<List<Orders>>(productlist);
            ListOrders.ItemsSource = productlistConvert;
        }

        async private void ImageButton_Clicked(object sender, EventArgs e)
        {
            ImageButton button = (ImageButton)sender;
            Orders product = button.CommandParameter as Orders;
            HttpClient httpClient = new HttpClient();
            String addCart = await httpClient.GetStringAsync($"{App.Localhost}/order/successstatus?UserID="+App.UserID+"&OrderID="+ product.ORDERID);
            await DisplayAlert("Thông Báo", "cập nhật thành công", "OK");
            listInit();
        }

        async private void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            ImageButton button = (ImageButton)sender;
            Orders product = button.CommandParameter as Orders;
            HttpClient httpClient = new HttpClient();
            String addCart = await httpClient.GetStringAsync($"{App.Localhost}/order/failstatus?UserID=" + App.UserID + "&OrderID=" + product.ORDERID);
            await DisplayAlert("Thông Báo", "Thêm nhật thành công", "OK");
            listInit();
        }
    }
}