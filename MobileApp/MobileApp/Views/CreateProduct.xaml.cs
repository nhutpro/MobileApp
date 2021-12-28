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
    public partial class CreateProduct : ContentPage
    {
        public CreateProduct()
        {
            InitializeComponent();
            string[] type = new string[]
            {
                "kem chống nắng", "sữa rửa mặt","toner","serum"
            };
            pkType.ItemsSource = type;
            pkType.SelectedIndex = 0;
        }

      async  private void createProduct_Clicked(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            var productlist = await httpClient.GetStringAsync($"{App.Localhost}/product/create?name={name.Text}&image={image.Text}&brand={branch.Text}&price={price.Text}&desciption={description.Text}&stock={stock.Text}&type={pkType.Items[pkType.SelectedIndex]}");
            await DisplayAlert("Thông báo", "Thêm sản phẩm thành công", "Ok");
            await Navigation.PopAsync();

        }
    }
}