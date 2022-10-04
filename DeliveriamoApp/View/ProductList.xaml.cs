
using DeliveriamoApp.ViewModel;
using DeliveriamoClient;

namespace DeliveriamoApp.View;

public partial class ProductList : ContentPage
{
	private ShopKeeperDto shopKeeperSource;
	private ProductListViewModel model;

	public ProductList()
	{
		InitializeComponent();
	
	}

	public ProductList(ShopKeeperDto shopKeeperSource)
	{
        InitializeComponent();

		this.shopKeeperSource = shopKeeperSource;
		// cast del viewmodel --
		model = (ProductListViewModel)BindingContext;
		// richiamo il comando PerformeSearch per eseguire la query (GetProductsByShopKeeperId)
		model.PerformSearch.Execute(shopKeeperSource.Id);
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{

		var btn = (Button)sender;
		var id = (int)btn.CommandParameter;
        var vm = (ProductListViewModel)BindingContext;
		var product = vm.ProductsListResult.FirstOrDefault(x => x.Id == id);

		if (vm.CartItems == null)
		{
			vm.CartItems = new List<ProductDto>();
		}
		var oldCartItems = vm.CartItems;

		oldCartItems.Add(product);

		vm.CartItems = oldCartItems;

		
    }
}