using pandemieAndroid.Models;

namespace pandemieAndroid;

public partial class MembruCrud : ContentPage
{
	public MembruCrud()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var membru = (Membru)BindingContext;


        await App.DatabaseMembru.SaveMembruAsync(membru);

        await Navigation.PopAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var membru = (Membru)BindingContext;

        await App.DatabaseMembru.DeleteMembruAsync(membru);

        await Navigation.PopAsync();
    }
}