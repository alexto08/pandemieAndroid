using pandemieAndroid.Models;

namespace pandemieAndroid;

public partial class TipPage : ContentPage
{
	public TipPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.DatabaseTip.GetTipAsync();
    }

    async void OnTipAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TipCrud
        {
            BindingContext = new Tip()
        });
    }

    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new TipCrud
            {
                BindingContext = e.SelectedItem as Tip
            });
        }
    }
}