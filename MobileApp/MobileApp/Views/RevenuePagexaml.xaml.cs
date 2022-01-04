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
    public partial class RevenuePagexaml : ContentPage
    {
        public RevenuePagexaml()
        {
            InitializeComponent();
            ListInit();
        }
       public void ListInit()
        {

            mainrevenue.IsVisible = false;
            string[] month = new string[]
            {
                "1", "2","3","4","5","6","7","8","9","10","11","12"
            };
            pkMonth.ItemsSource = month;
            pkMonth.SelectedIndex = 0;
        }
       async private void revenue_Clicked(object sender, EventArgs e)
        {
            
            if (Regex.Match(year.Text, $"[1-2][0-9][0-9][0-9]").Success)
            {
                mainrevenue.IsVisible = false;
                HttpClient httpClient = new HttpClient();
                var productlist = await httpClient.GetStringAsync($"{App.Localhost}/order/allsuccess?month={pkMonth.Items[pkMonth.SelectedIndex]}&year={year.Text}");
                var productlistConvert = JsonConvert.DeserializeObject<List<Orders>>(productlist);
                
                if (productlistConvert.Count == 0)
                {
                    await DisplayAlert("OK", "Tháng này không có doanh thu", "OK");
                }
                else
                {
                    mainrevenue.IsVisible = true;
                    float sum = 0;
                    listRevenue.ItemsSource = productlistConvert;
                    totalorder.Text = productlistConvert.Count.ToString();
                    foreach (Orders order in productlistConvert)
                    {
                        sum += order.PRICE * order.NUMBER;
                    }
                    totalrevenue.Text = String.Format("{0:#,0}", sum) + "đ";
                }
            }
        else
            {
                await DisplayAlert("Thông Báo", "Xin vui lòng nhập lại năm", "OK");
            }
          
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
      
            ListInit();



        }

    }
}