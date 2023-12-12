using Plugin.LocalNotification;
using Sinca_Teodora_Lab7.Models;
namespace Sinca_Teodora_Lab7;

public partial class ShopPage : ContentPage
{
	public ShopPage()
	{
		InitializeComponent();

	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
	{
		var shop = (Shop)BindingContext; 
		await App.Database.SaveShopAsync(shop);
		await Navigation.PopAsync(); 
	}
    async void OnShowMapButtonClicked(object sender, EventArgs e)
    {
        var shop = (Shop)BindingContext;
		var address = shop.Adress; 
		var locations = await Geocoding.GetLocationsAsync(address); 
		var options = new MapLaunchOptions { Name = "Magazinul meu preferat" };
        var location = locations?.FirstOrDefault();       
		// var myLocation = await Geolocation.GetLocationAsync();
		var myLocation = new Location(46.7731796289, 23.6213886738);
             
        var distance = myLocation.CalculateDistance(location, DistanceUnits.Kilometers);
		if (distance < 4)
        {
            var request = new NotificationRequest { 
				Title = "Ai de facut cumparaturi in apropiere!",
				Description = address, 
				Schedule = new NotificationRequestSchedule
				{
					NotifyTime = DateTime.Now.AddSeconds(1) 
				}
			};
            LocalNotificationCenter.Current.Show(request);
        }
        await Map.OpenAsync(location, options);
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
	{
        bool answer = await DisplayAlert("Confirm Deletion", "Are you sure you want to delete this shop?", "Yes", "No");

		if (answer)
		{
			var shop = (Shop)BindingContext;

			// Assuming App.Database.DeleteShopAsync method is available in your App class
			await App.Database.DeleteShopAsync(shop);

			await Navigation.PopAsync();
		}
        }

}