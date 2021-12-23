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
    public partial class CartPage : ContentPage
    {
        float sum = 0;
        public CartPage()
        {  
            InitializeComponent();
           
        }
        
        private void Button_Clicked(object sender, EventArgs e)
        {
            
        }
        async public void ListInit()
        {

            sum = 0;
            HttpClient httpClientcart = new HttpClient();
            var productlist = await httpClientcart.GetStringAsync("http://172.23.96.1/MobileAPI/cart?UserID=" + App.UserID);
            var productlistConvert = JsonConvert.DeserializeObject<List<CartItems>>(productlist);
            
            if (productlistConvert.Count == 0)
            {
                empty.IsVisible = true;
                listCart.IsVisible = false;
                Total.IsVisible = false;
            }
            else
            {
                empty.IsVisible = false;
                listCart.IsVisible = true;
                listCart.ItemsSource = productlistConvert;
             
                foreach (CartItems item in productlistConvert)
                {
                    sum = sum + (item.PRICE * item.NUMBER);
                  
                }
                total.Text = String.Format("{0:#,0}", sum) + "đ";
                Total.IsVisible = true;


            }
        


        }

       async private void ImageButton_Clicked(object sender, EventArgs e)
        {   
            ImageButton button = (ImageButton)sender;
            Label label = button.Parent.FindByName("lblNum") as Label;
            CartItems selectedPro = button.CommandParameter as CartItems;
            if (label.Text == "1")
            {
                await DisplayAlert("Thông Báo", "Không thể giảm ", "OK");
            }
            else
            {
                HttpClient httpClient = new HttpClient();
                var send = await httpClient.GetStringAsync("http://172.23.96.1/MobileAPI/cart/subtract?userID="+ App.UserID + "&procID=" + selectedPro.PRODUCTID);
                sum = sum - selectedPro.PRICE;
                label.Text = (Int32.Parse(label.Text) - 1).ToString();
                total.Text = String.Format("{0:#,0}", sum) + "đ";
            }
            
        }

       async private void ImageButton_Clicked_1(object sender, EventArgs e)
        {   
            ImageButton button = (ImageButton)sender;
            Label label = button.Parent.FindByName("lblNum") as Label;

            CartItems selectedPro = button.CommandParameter as CartItems;
           
            if(int.Parse(label.Text) == selectedPro.STOCK)
            {
               await DisplayAlert("Thông Báo", "Số lượng đã đạt tối đa", "OK");
            }
            else
            {
                HttpClient httpClient = new HttpClient();
                var send = await httpClient.GetStringAsync("http://172.23.96.1/MobileAPI/cart/plus?userID=" + App.UserID + "&procID=" + selectedPro.PRODUCTID);
                sum = sum + selectedPro.PRICE;
                label.Text = (Int32.Parse(label.Text) + 1).ToString();
                total.Text = String.Format("{0:#,0}", sum) + "đ";

            }
            
            
        }

       async  private void Button_Clicked_1(object sender, EventArgs e)
        {   
            Button button = (Button)sender;
            CartItems selectedPro = button.CommandParameter as CartItems;
            HttpClient httpClient = new HttpClient();
            var send = await httpClient.GetStringAsync("http://172.23.96.1/MobileAPI/cart/delete?userID=" + App.UserID + "&procID=" + selectedPro.PRODUCTID);
            ListInit();
            
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PaymentPage());
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ListInit();
        }

        private void listCart_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            else
            {
                ((ListView)sender).SelectedItem = null;
            }

        }
    }
}