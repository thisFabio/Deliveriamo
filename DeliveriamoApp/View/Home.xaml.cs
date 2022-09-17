namespace DeliveriamoApp.View;

public partial class Home : ContentPage
{
	public Home()
	{
		InitializeComponent();
		if (String.IsNullOrEmpty(((App)App.Current).Token))
		{
			 
		} 

    }

	private async void SupermercatiButton_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new Search());
	}

	private async void RistorantiButton_Clicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new Search());
    }
}