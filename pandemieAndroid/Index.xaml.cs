
using pandemieAndroid.Models;

namespace pandemieAndroid;

public partial class Index : ContentPage
{
	public Index()
	{
		InitializeComponent();
	}

    async void OnTipClicked(object sender, EventArgs e)
    {
        var selectedVaccin = ((Button)sender).CommandParameter as Tip;
        await Navigation.PushAsync(new TipPage());
    }

    async void OnTaraClicked(object sender, EventArgs e)
    {
        var selectedVaccin = ((Button)sender).CommandParameter as Tara;
        await Navigation.PushAsync(new TaraPage());
    }
}