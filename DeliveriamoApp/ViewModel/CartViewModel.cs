using CommunityToolkit.Mvvm.ComponentModel;
using DeliveriamoClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DeliveriamoApp.ViewModel
{
    public class CartViewModel : ObservableObject
    {

        private List<ProductDto> productList = ((App)App.Current).CartItems;
        private ProductDto selectedProduct;

        public ProductDto SelectedProduct 
        { 
            get
            {
                return selectedProduct;
            } set 
            { 
                this.SetProperty(ref selectedProduct, value);

            }
        }

        public List<ProductDto> ProductList
        {
            get
            {
                return productList;
            }
            set
            {
                this.SetProperty(ref productList, value);
            }

        }

        public ICommand RemoveFromCart => new Command(async () => // definisco il tipo di comando e il suo datatype in INPUT
        {
            ProductList.Remove(SelectedProduct);
        });


    }
}
