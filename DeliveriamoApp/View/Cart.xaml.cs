using DeliveriamoApp.ViewModel;
using DeliveriamoClient;

namespace DeliveriamoApp.View;

public partial class Cart : ContentPage
{
	public Cart()
	{
		InitializeComponent();
	}


    private void Button_Clicked(object sender, EventArgs e)
	{

	}

    protected async override void OnAppearing()
    {

		//base.OnAppearing();
		//var vm = BindingContext;
		//BindingContext = vm;
		//vm.ProductList = ((App)App.Current).CartItems;

	}
}