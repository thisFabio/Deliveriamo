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
    public class SearchViewModel : ObservableObject
    {

        public ICommand PerformSearch => new Command<string>(async (string query) =>
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", ((App)App.Current).Token);

                var client = new Client("https://localhost:7232", httpClient);
                var res = await client.GetShopKeepersAsync(query, ((App)App.Current).IsRestaurant, ((App)App.Current).IsSupermarket);


                if (res.Success)
                {
                    SearchResults = res.ShopKeepers.ToList();
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Attenzione", String.IsNullOrEmpty(res.ErrorMessage) ? "Errore di ricerca." : res.ErrorMessage, "Ok");
                }

            }
        });

        private ShopKeeperDto selectedShopKeeper;
        private List<ShopKeeperDto> searchResults;
        public ShopKeeperDto SelectedShopKeeper
        {
            get
            {
                return selectedShopKeeper;
            }
            set
            {
                this.SetProperty(ref selectedShopKeeper, value);
            }
        }
        public List<ShopKeeperDto> SearchResults
        {
            get
            {
                return searchResults;
            }
            set
            {
                this.SetProperty(ref searchResults, value);

            }
        }
    }
}
