using pandemieAndroid.Models;
using pandemieAndroid.Data;

namespace pandemieAndroid;

public partial class pandemie : ContentPage
{
    public pandemie()
    {

        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.DatabaseMembru.GetMembruAsync();
    }
    async void OnAchizitieAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AchizitiePage
        {
            BindingContext = new Achizitie()
        });
    }
    async void OnVaccinItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new VaccinPage
            {
                BindingContext = e.SelectedItem as Vaccin
            });
        }

    }


    async void OnVaccinSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new VaccinPage
            {
                BindingContext = e.SelectedItem as Vaccin
             });
        }
    }

    async void OnTipSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new TipPage
            {
                BindingContext = e.SelectedItem as Tip
            });
        }
    }
}