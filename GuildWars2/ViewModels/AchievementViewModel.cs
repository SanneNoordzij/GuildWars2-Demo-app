using System;
using System.Windows.Input;
using GuildWars2.Helpers;
using GuildWars2.Utils;
using Xamarin.Forms;

namespace GuildWars2.ViewModels
{
	public class AchievementViewModel : BaseViewModel
	{
		public ICommand Logout { get; private set; }
		public AchievementViewModel()
		{
			Logout = new Command(() =>
			{
				Settings.ApiKey = string.Empty;
				NavigationService.SetRoot(new EnterKeyViewModel());
			});
		}
	}
}
