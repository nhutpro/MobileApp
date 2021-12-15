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
    public partial class PaymentPage : ContentPage
    {   float sum = 0;
        public PaymentPage()
        {
            InitializeComponent();
            ListInit();
            
        }

        async public void ListInit()
        {
            sum = 0;
            HttpClient httpClient = new HttpClient();
            var productlist = await httpClient.GetStringAsync("http://172.18.128.1/MobileAPI/cart?userID=USE01");
            var productlistConvert = JsonConvert.DeserializeObject<List<CartItems>>(productlist);
          
                listpayment.ItemsSource = productlistConvert;

                foreach (CartItems item in productlistConvert)
                {
                    sum = sum + (item.PRICE * item.NUMBER);
                    await DisplayAlert("OK", item.NUMBER.ToString(), "OK");
                }
                total.Text = String.Format("{0:#,0}", sum + (float)30000) + "đ";
       





        }
    }
}