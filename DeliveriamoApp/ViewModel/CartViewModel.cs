using CommunityToolkit.Mvvm.ComponentModel;
using DeliveriamoClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DeliveriamoApp.ViewModel
{
    public class CartViewModel : ObservableObject
    {
        public CartViewModel()
        {
            ProductList = new List<ProductDto>()
            {
                new ProductDto()
                {
                    Id = 1,
                    Name = "pippo"
                },
                new ProductDto()
                {
                    Id = 2,
                    Name = "pluto"
                },
                new ProductDto()
                {
                    Id = 3,
                    Name = "paperino"
                }
            };
        }
        public ProductDto SelectedProduct
        {
            get
            {
                return selectedProduct;
            }
            set
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
                OnPropertyChanged(nameof(ProductList));
            }

        }

        private List<ProductDto> productList = ((App)App.Current).CartItems;
        private ProductDto selectedProduct;
        public ICommand RemoveFromCart => new Command(async () => // definisco il tipo di comando e il suo datatype in INPUT
        {
            ProductList.Remove(SelectedProduct);
        });


    }
}
