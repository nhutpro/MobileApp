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
    public partial class RevenuePagexaml : ContentPage
    {
        public RevenuePagexaml()
        {
            InitializeComponent();
            ListInit();
        }
        async public void ListInit()
        {
            List<Orders> listOrder = new List<Orders>();
            HttpClient httpClient = new HttpClient();
            var productlist = await httpClient.GetStringAsync($"{App.Localhost}/order/success?UserID=" + App.UserID);
            var productlistConvert = JsonConvert.DeserializeObject<List<Orders>>(productlist);
            listRevenue.ItemsSource = productlistConvert;
        }
    }
}