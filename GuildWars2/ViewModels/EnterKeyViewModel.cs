using System;
using System.Windows.Input;
using GuildWars2.Helpers;
using GuildWars2.Utils;
using Xamarin.Forms;

namespace GuildWars2.ViewModels
{
	public class EnterKeyViewModel : BaseViewModel
	{
		public ICommand GoToNextPage { get; private set; }

		string _ApiKey;
		public string ApiKey
		{
			get
			{
				return _ApiKey;
			}
			set
			{
				if (_ApiKey != value)
				{
					_ApiKey = value;
					OnPropertyChanged("ApiKey");
				}
			}
		}

		public EnterKeyViewModel()
		{
			GoToNextPage = new Command(() =>
			{
				Settings.ApiKey = ApiKey;
				NavigationService.SetRoot(new AchievementViewModel());
			}, () => false);
		}
	}
}

