using pandemieAndroid.Models;

namespace pandemieAndroid;

public partial class ProducatoriPage : ContentPage
{
	public ProducatoriPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.DatabaseProducator.GetProducatorAsync();
    }

    async void OnProducatorAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProducatoriCrud
        {
            BindingContext = new Producator()
        });
    }

    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ProducatoriCrud
            {
                BindingContext = e.SelectedItem as Producator
            });
        }
    }
}