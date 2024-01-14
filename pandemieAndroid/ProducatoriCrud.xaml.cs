using pandemieAndroid.Models;

namespace pandemieAndroid;

public partial class ProducatoriCrud : ContentPage
{
	public ProducatoriCrud()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var producator = (Producator)BindingContext;


        await App.DatabaseProducator.SaveProducatorAsync(producator);

        await Navigation.PopAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var producator = (Producator)BindingContext;

        await App.DatabaseProducator.DeleteProducatorAsync(producator);

        await Navigation.PopAsync();
    }
}