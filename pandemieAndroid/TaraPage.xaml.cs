using pandemieAndroid.Models;

namespace pandemieAndroid;

public partial class TaraPage : ContentPage
{
    public TaraPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.DatabaseTara.GetTaraAsync();
    }

    async void OnTaraAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TaraCrud
        {
            BindingContext = new Tara()
        });
    }

    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new TaraCrud
            {
                BindingContext = e.SelectedItem as Tara
            });
        }
    }
}