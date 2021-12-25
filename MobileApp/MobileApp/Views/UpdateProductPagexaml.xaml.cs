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
    public partial class UpdateProductPagexaml : ContentView
    {
        Products product;
        public UpdateProductPagexaml()
        {
            InitializeComponent();
            
        }
        public UpdateProductPagexaml(Products p)
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
        }
    }
}