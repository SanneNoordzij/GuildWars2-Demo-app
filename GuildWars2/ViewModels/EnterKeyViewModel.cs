using System;
using System.Windows.Input;
using GuildWars2.Utils;
using Xamarin.Forms;

namespace GuildWars2.ViewModels
{
	public class EnterKeyViewModel : BaseViewModel
	{
		public ICommand GoToNextPage { get; private set; }
		public EnterKeyViewModel()
		{
			GoToNextPage = new Command(() => { NavigationService.SetRoot(new AchievementViewModel()); });
		}
	}
}

