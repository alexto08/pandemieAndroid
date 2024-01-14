using pandemieAndroid.Models;

namespace pandemieAndroid;

public partial class TaraCrud : ContentPage
{
	public TaraCrud()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var tara = (Tara)BindingContext;


        await App.DatabaseTara.SaveTaraAsync(tara);

        await Navigation.PopAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var tara = (Tara)BindingContext;

        await App.DatabaseTara.DeleteTaraAsync(tara);

        await Navigation.PopAsync();
    }
}