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
        List<CartItems> cartItemList= new List<CartItems>();
        public PaymentPage()
        {
            InitializeComponent();
            ListInit();
            
        }

        async public void ListInit()
        {
            sum = 0;
            HttpClient httpClient = new HttpClient();
            var productlist = await httpClient.GetStringAsync($"{App.Localhost}/cart?userID="+ App.UserID);
            var productlistConvert = JsonConvert.DeserializeObject<List<CartItems>>(productlist);
          
                listpayment.ItemsSource = productlistConvert;
                cartItemList = productlistConvert;
                foreach (CartItems item in productlistConvert)
                {
                    sum = sum + (item.PRICE * item.NUMBER);
                   
                }
                total.Text = String.Format("{0:#,0}", sum + (float)30000) + "đ";
         
            var userlist = await httpClient.GetStringAsync($"{App.Localhost}/user/getbyid?userID=" + App.UserID);
            List<User>  userlistConvert = JsonConvert.DeserializeObject<List<User>>(userlist);
            
            
            User user = userlistConvert.ElementAt(0);
            name.Text = user.FullName;
            phone.Text = user.Phone;
            address.Text = user.Address;
        }

      async  private void Button_Clicked(object sender, EventArgs e)
        {   
            foreach(CartItems item in cartItemList)
            {
                HttpClient httpClient = new HttpClient();
              
               var productlist = await httpClient.GetStringAsync($"{App.Localhost}/order/add?UserID=" + App.UserID + "&ProID=" + item.PRODUCTID + "&number=" + item.NUMBER);
            }
          await Navigation.PopAsync();
        }
    }
}