using GuildWars2.Utils;
using Xamarin.Forms;
using GuildWars2.Pages;
using GuildWars2.ViewModels;
using Xamarin.Forms.Xaml;
using GuildWars2.Helpers;
using Akavache;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace GuildWars2
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			SimpleIoC.RegisterPage<EnterKeyViewModel, EnterKeyPage>();
			SimpleIoC.RegisterPage<AchievementViewModel, AchievementPage>();
			SimpleIoC.RegisterPage<AchievementDetailViewModel, AchievementDetailPage>();
			BlobCache.ApplicationName = "Akavache";

			if (string.IsNullOrEmpty(Settings.ApiKey))
			{
				NavigationService.SetRoot(new EnterKeyViewModel());
				return;
			}
			NavigationService.SetRoot(new AchievementViewModel());
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
