using pandemieAndroid.Models;

namespace pandemieAndroid;

public partial class AchizitieCrud : ContentPage
{
	public AchizitieCrud()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var achizitie = (Achizitie)BindingContext;

        achizitie.Data_achizitie = DateTime.UtcNow;

        await App.DatabaseAchizitie.SaveAchizitieAsync(achizitie);

        await Navigation.PopAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var achizitie = (Achizitie)BindingContext;

        await App.DatabaseAchizitie.DeleteAchizitieAsync(achizitie);

        await Navigation.PopAsync();
    }
}