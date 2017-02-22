using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace GuildWars2.Pages
{
	public partial class EnterKeyPage : ContentPage
	{
		public EnterKeyPage()
		{
			InitializeComponent();
		}

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			var scanPage = new ZXingScannerPage();

			scanPage.OnScanResult += (result) =>
			{
				// Stop scanning
				scanPage.IsScanning = false;

				// Pop the page and show the result
				Device.BeginInvokeOnMainThread(() =>
				{
					apiKeyEntry.Text = result.Text;
					Navigation.PopAsync();
				});
			};

			// Navigate to our scanner page
			await Navigation.PushAsync(scanPage);
		}
	}
}
