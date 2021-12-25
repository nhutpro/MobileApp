using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MobileApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileApp.Views;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminProductDetailPage : ContentPage
    { Products product = new Products();
        public AdminProductDetailPage()
        {
            InitializeComponent();
        }
        public AdminProductDetailPage(Products p)
        {
            InitializeComponent();
            this.product = p;
            Init();
        }
        void Init()
        {
            ProductImg.Source = product.IMAGE;
            NameLbl.Text = product.NAME;
            DescriptionLbl.Text = product.DESCRIPTION;
            branch.Text = product.BRAND;
            price.Text = String.Format("{0:#,0}", product.PRICE) +" đ";
            stock.Text = String.Format("{0:#,0}", product.STOCK) +" sản phẩm";
        }

       async private void Button_Clicked(object sender, EventArgs e)
        {
           var choice = await DisplayAlert("Thông Báo", "Bạn muốn xoá sản phẩm này", "OK", "Cancel");
            if(choice)
            {
                HttpClient httpClient = new HttpClient();
                var productlist = await httpClient.GetStringAsync($"{App.Localhost}/product/delete?ProID={product.PRODUCTID}");
                await DisplayAlert("Thông Báo", "Xoá sản phẩm thành công", "OK");
              await  Navigation.PopAsync();
            } 
             
           
            
        }

  private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AdminUpdateProduct(product));
        }
    }
}