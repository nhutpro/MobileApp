using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        List<Product> products = new List<Product>();

        void init()
        {
            products.Add(new Product { ID = 1 });
            products.Add(new Product { ID = 2 });
            products.Add(new Product { ID = 3 });
            products.Add(new Product { ID = 4 });
            products.Add(new Product { ID = 5 });
            products.Add(new Product { ID = 6 });
            products.Add(new Product { ID = 7 });
            lst.ItemsSource = products;
        }

        public HomePage()
        {
            InitializeComponent();
            init();
        }
    }
}