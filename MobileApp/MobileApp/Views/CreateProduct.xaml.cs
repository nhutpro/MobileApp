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
    public partial class CreateProduct : ContentPage
    {
        public CreateProduct()
        {
            InitializeComponent();
            string[] type = new string[]
            {
                "kem chong nang", "sua rua mat","toner","serum"
            };
            pkType.ItemsSource = type;
        }
    }
}