using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MobileApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminUpdateProduct : ContentPage
    {
        Products product;
        public AdminUpdateProduct()
        {
            InitializeComponent();
        }
        public AdminUpdateProduct(Products p)
        {
            InitializeComponent();
            this.product = p;
            Init();
        }
        void Init()
        {
            ProductImg.Source = product.IMAGE;
            name.Text = product.NAME;
            description.Text = product.DESCRIPTION;
            branch.Text = product.BRAND;
            price.Text = product.PRICE.ToString();
            stock.Text = product.STOCK.ToString();
            string[] type = new string[]
            {
                "kem chống nắng", "sữa rửa mặt","toner","serum"
            };
            pktype.ItemsSource = type;
            if(product.TYPE == "kem chống nắng")
            {
                pktype.SelectedIndex = 0;
            }
            else if(product.TYPE == "sữa rửa mặt")
            {
                pktype.SelectedIndex = 1;
            }
            else if (product.TYPE == "toner")
            {
                pktype.SelectedIndex = 2;
            }
            else
            {
                pktype.SelectedIndex = 3;
            }

        }

       async  private void updateProduct_Clicked(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            var productlist = await httpClient.GetStringAsync($"{App.Localhost}/product/update?ProID={product.PRODUCTID}&name={name.Text}&brand={branch.Text}&price={price.Text}&desciption={description.Text}&stock={stock.Text}&type={pktype.Items[pktype.SelectedIndex]}");
            await DisplayAlert("Thông báo ", "Cập nhật thành công", "OK");
            await Navigation.PopAsync();
        }
    }
}