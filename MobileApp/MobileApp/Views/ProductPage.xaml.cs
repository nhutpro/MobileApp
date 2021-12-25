using MobileApp.Models;
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
    public partial class ProductPage : ContentPage
    {
        Products p = new Products();
        string currentUserID;
        public ProductPage( Products p)
        {
            InitializeComponent();
            this.p = p;
            ProductImg.Source = p.IMAGE;
            NameLbl.Text = p.NAME;
            BrandLbl.Text = p.BRAND;
            DescriptionLbl.Text = p.DESCRIPTION;
            PriceLbl.Text = String.Format("{0:#,0}", p.PRICE);
            StockLbl.Text = p.STOCK.ToString();
        }

      async   private void addToCartBtn_Clicked(object sender, EventArgs e)
        {
            
            HttpClient httpClient = new HttpClient();
            String addCart = await httpClient.GetStringAsync($"{App.Localhost}/product/addcart?UserID=" + App.UserID + "&ProID=" + p.PRODUCTID);
            await DisplayAlert("Thông Báo", "Thêm vào giỏ hàng thành công", "OK");
            await Navigation.PopAsync();

        }
    }
}