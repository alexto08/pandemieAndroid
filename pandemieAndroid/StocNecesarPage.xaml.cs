using pandemieAndroid.Models;

namespace pandemieAndroid;

public partial class StocNecesarPage : ContentPage
{
	public StocNecesarPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.DatabaseStocNecesar.GetStocNecesarAsync();
    }

    async void OnStocNecesarAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new StocNecesarCrud
        {
            BindingContext = new StocNecesar()
        });
    }

    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new StocNecesarCrud
            {
                BindingContext = e.SelectedItem as StocNecesar
            });
        }
    }
}
