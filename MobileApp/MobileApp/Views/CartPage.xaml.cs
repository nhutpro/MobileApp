using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartPage : ContentPage
    {
        public CartPage()
        {
            InitializeComponent();
            List<Item> item = new List<Item>();
            for (var i = 0; i < 5; i++)
            {
                item.Add(new Item { Id = "1", Description = "Thuốc trừ sâu", Name = "Thuốc trừ sâu", Image = "anhthuoc.jpg", Price = 1000000 });
            }

            listCart.ItemsSource = item;
        }
    }
}