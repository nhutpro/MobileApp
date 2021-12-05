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
    public partial class DashBoardPage : ContentPage
    {
        public DashBoardPage()
        {
            InitializeComponent();
            List<Item> item = new List<Item>();
            item.Add(new Item { Id = "Thuốc Trừ Sâu", Description = "ahihi", Text = "450000" });
            LskItems.ItemsSource = item;
        }
    }
}