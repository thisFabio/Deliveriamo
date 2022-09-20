//using Deliveriamo.DTOs.Product;
using DeliveriamoClient;

namespace DeliveriamoApp.View;

public partial class Search : ContentPage
{
	public Search()
	{
		InitializeComponent();
	}
		//public ShopKeeperDto SelectedShopKeeperObject { get; set; }
       



    private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
	{

        //// salvare item clicked\selected in una proprietà.
        // SelectedShopKeeperObject = (ShopKeeperDto)e.SelectedItem;
        
        //// reindirizzare su una nuova pagina
        //await Navigation.PushAsync(new ProductList(SelectedShopKeeperObject));

    }

}


