using System;
using System.Diagnostics;
using System.Windows.Input;
using GuildWars2.API;
using GuildWars2.Helpers;
using GuildWars2.Models;
using GuildWars2.Utils;
using Refit;
using Xamarin.Forms;

namespace GuildWars2.ViewModels
{
	public class AchievementViewModel : BaseViewModel
	{
		public ObservableRangeCollection<DetailAchievementModel> Achievements { get; set; }
		public ICommand Logout { get; private set; }

		public AchievementViewModel()
		{
			Achievements = new ObservableRangeCollection<DetailAchievementModel>();
			Logout = new Command(() =>
			{
				Settings.ApiKey = string.Empty;
				NavigationService.SetRoot(new EnterKeyViewModel());
			});
			RetrieveAchievements();
		}

		async void RetrieveAchievements()
		{
			IsBusy = true;
			try
			{
				var guildWars2Api = RestService.For<IGuildWarsApi>(Constants.BaseUrl);
				var achievements = await guildWars2Api.GetDailyAchievements();
				var detailedAchievements = await guildWars2Api.GetDetailInformationAboutAchievements(CreateIdString(achievements));
				Achievements.AddRange(detailedAchievements);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
			IsBusy = false;
		}

		string CreateIdString(DailyAchievementModel model)
		{
			string ids = string.Empty;
			foreach (DailyAchievementSummaryModel summary in model.PvE)
			{
				ids += summary.Id + ",";
			}
			foreach (DailyAchievementSummaryModel summary in model.PvP)
			{
				ids += summary.Id + ",";
			}
			foreach (DailyAchievementSummaryModel summary in model.WvW)
			{
				ids += summary.Id + ",";
			}
			return ids.Remove(ids.Length - 1);
		}
	}
}
