using pandemieAndroid.Models;

namespace pandemieAndroid;

public partial class AchizitiePage : ContentPage
{
	public AchizitiePage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.DatabaseAchizitie.GetAchizitieAsync();
    }

    async void OnAchizitieAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AchizitieCrud
        {
            BindingContext = new Achizitie()
        });
    }

    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new AchizitieCrud
            {
                BindingContext = e.SelectedItem as Achizitie
            });
        }
    }
}
