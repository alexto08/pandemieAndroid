using pandemieAndroid.Models;

namespace pandemieAndroid;

public partial class MembruPage : ContentPage
{
	public MembruPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.DatabaseMembru.GetMembruAsync();
    }

    async void OnMembruAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MembruCrud
        {
            BindingContext = new Membru()
        });
    }

    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new MembruCrud
            {
                BindingContext = e.SelectedItem as Membru
            });
        }
    }
}