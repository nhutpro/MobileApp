using MobileApp.Models;
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

        private void addToCartBtn_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}