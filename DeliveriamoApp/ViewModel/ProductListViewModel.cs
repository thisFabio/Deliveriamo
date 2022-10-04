
//using Android.App.AppSearch;
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
    public class ProductListViewModel : ObservableObject
    {
        private ProductDto selectedProduct;
        private List<ProductDto> productsListResult;
        private List<ProductDto> cartItems;
        public List<ProductDto> CartItems
        {
            get
            {
                return cartItems;
            }
            set
            {
                this.SetProperty(ref cartItems, value);
                OnPropertyChanged();

            }
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
        public List<ProductDto> ProductsListResult
        {
            get
            {
                return productsListResult;
            }
            set
            {
                this.SetProperty(ref productsListResult, value);

            }
        }
        

        // comando per eseguire le chiamate API(in questo caso CRUD)
        public ICommand PerformSearch => new Command<int>(async (int id) => // definisco il tipo di comando e il suo datatype in INPUT
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", ((App)App.Current).Token);

                var client = new Client("https://localhost:7232", httpClient);
                // eseguo l'istruzione della chiamata api
                var res = await client.GetProductByShopKeeperIdAsync(id);

                if (res.Success)
                {
                    ProductsListResult = res.Products.ToList();
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Attenzione", String.IsNullOrEmpty(res.ErrorMessage) ? "Errore di ricerca." : res.ErrorMessage, "Ok");
                }

            }
        });

        // comando per aggiungere prodotti al carrello
        public ICommand AddToCart => new Command(async () => // definisco il tipo di comando e il suo datatype in INPUT
        {
            // add product 
            ((App)App.Current).CartItems.Add(SelectedProduct);

        });
    }
}
