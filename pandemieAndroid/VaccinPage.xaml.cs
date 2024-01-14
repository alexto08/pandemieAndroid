using pandemieAndroid.Models;

namespace pandemieAndroid;

public partial class VaccinPage : ContentPage
{
	public VaccinPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.DatabaseVaccin.GetVaccinAsync();
    }

    async void OnVaccinAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new VaccinCrud
        {
            BindingContext = new Vaccin()
        });
    }

    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new VaccinCrud
            {
                BindingContext = e.SelectedItem as Achizitie
            });
        }
    }
}