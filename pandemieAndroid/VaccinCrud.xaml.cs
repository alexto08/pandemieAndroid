using pandemieAndroid.Models;

namespace pandemieAndroid;

public partial class VaccinCrud : ContentPage
{
	public VaccinCrud()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var vaccin = (Vaccin)BindingContext;


        await App.DatabaseVaccin.SaveVaccinAsync(vaccin);

        await Navigation.PopAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var vaccin = (Vaccin)BindingContext;

        await App.DatabaseVaccin.DeleteVaccinAsync(vaccin);

        await Navigation.PopAsync();
    }
}