using pandemieAndroid.Models;

namespace pandemieAndroid;

public partial class StocNecesarCrud : ContentPage
{
	public StocNecesarCrud()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var stocNecesar = (StocNecesar)BindingContext;

        await App.DatabaseStocNecesar.SaveStocNecesarAsync(stocNecesar);

        await Navigation.PopAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var stocNecesar = (StocNecesar)BindingContext;

        await App.DatabaseStocNecesar.DeleteStocNecesarAsync(stocNecesar);

        await Navigation.PopAsync();
    }
}