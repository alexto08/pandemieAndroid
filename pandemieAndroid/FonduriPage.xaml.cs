using pandemieAndroid.Models;

namespace pandemieAndroid;

public partial class FonduriPage : ContentPage
{
	public FonduriPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.DatabaseFond.GetFondAsync();
    }

    async void OnFondAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FonduriCrud
        {
            BindingContext = new Fond()
        });
    }

    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new FonduriCrud
            {
                BindingContext = e.SelectedItem as Fond
            });
        }
    }
}