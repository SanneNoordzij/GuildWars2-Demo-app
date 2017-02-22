using GuildWars2.Utils;
using Xamarin.Forms;
using GuildWars2.Pages;
using GuildWars2.ViewModels;
namespace GuildWars2
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			SimpleIoC.RegisterPage<EnterKeyViewModel, EnterKeyPage>();
			SimpleIoC.RegisterPage<AchievementViewModel, AchievementPage>();

			NavigationService.SetRoot(new EnterKeyViewModel(), false);
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
