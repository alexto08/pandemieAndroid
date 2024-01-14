using pandemieAndroid.Models;

namespace pandemieAndroid;

public partial class TipCrud : ContentPage
{
	public TipCrud()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var tip = (Tip)BindingContext;

        await App.DatabaseTip.SaveTipAsync(tip);

        await Navigation.PopAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var tip = (Tip)BindingContext;

        await App.DatabaseTip.DeleteTipAsync(tip);

        await Navigation.PopAsync();
    }
}