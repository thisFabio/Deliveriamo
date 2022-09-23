
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

}