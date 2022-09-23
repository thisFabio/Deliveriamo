
namespace DeliveriamoApp.View;

public partial class Home : ContentPage
{
	public Home()
	{
		InitializeComponent();

    }

    private async void SupermercatiButton_Clicked(object sender, EventArgs e)
	{
		((App)App.Current).IsSupermarket = true;
        await Navigation.PushAsync(new Search());
	}

	private async void RistorantiButton_Clicked(object sender, EventArgs e)
	{
        ((App)App.Current).IsRestaurant = true;
        await Navigation.PushAsync(new Search());
    }

}