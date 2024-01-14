using pandemieAndroid.Models;

namespace pandemieAndroid;

public partial class FonduriCrud : ContentPage
{
	public FonduriCrud()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var achizitie = (Fond)BindingContext;


        await App.DatabaseFond.SaveFondAsync(achizitie);

        await Navigation.PopAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var fond= (Fond)BindingContext;

        await App.DatabaseFond.DeleteFondAsync(fond);

        await Navigation.PopAsync();
    }
}