using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Akavache;
using GuildWars2.API;
using GuildWars2.Helpers;
using GuildWars2.Models;
using GuildWars2.Utils;
using Refit;
using Xamarin.Forms;
using System.Reactive.Linq;

namespace GuildWars2.ViewModels
{
	public class AchievementViewModel : BaseViewModel
	{
		public ObservableRangeCollection<DetailAchievementModel> Achievements { get; set; }

		DetailAchievementModel _SelectedItem;
		public DetailAchievementModel SelectedItem
		{
			get
			{
				return _SelectedItem;
			}
			set
			{
				_SelectedItem = value;
				OnPropertyChanged("SelectedItem");
				if (_SelectedItem != null)
				{
					GoToDetailPage(_SelectedItem);
					_SelectedItem = null;
					OnPropertyChanged("SelectedItem");
				}

			}
		}
		public ICommand Logout { get; private set; }

		public AchievementViewModel()
		{
			Achievements = new ObservableRangeCollection<DetailAchievementModel>();
			Logout = new Command(() =>
			{
				Settings.ApiKey = string.Empty;
				NavigationService.SetRoot(new EnterKeyViewModel());
			});
			GetConferences();
		}

		async void GoToDetailPage(DetailAchievementModel model)
		{
			await NavigationService.PushAsync(new AchievementDetailViewModel(model));
		}
		public async Task<List<DetailAchievementModel>> GetConferences()
		{
			var cache = BlobCache.LocalMachine;
			DateTimeOffset offset = new DateTimeOffset(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1));
			var cachedConferences = cache.GetAndFetchLatest(Constants.DailyAchievementAkavacheKey, RetrieveAchievements, absoluteExpiration: offset);

			var detailedAchievements = await cachedConferences.FirstOrDefaultAsync();
			Achievements.AddRange(detailedAchievements);
			return detailedAchievements;
		}
		async Task<List<DetailAchievementModel>> RetrieveAchievements()
		{
			List<DetailAchievementModel> models = new List<DetailAchievementModel>();
			IsBusy = true;
			try
			{
				var guildWars2Api = RestService.For<IGuildWarsApi>(Constants.BaseUrl);
				var achievements = await guildWars2Api.GetDailyAchievements();
				var detailedAchievements = await guildWars2Api.GetDetailInformationAboutAchievements(CreateIdString(achievements));
				models = detailedAchievements;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
			IsBusy = false;
			return models;
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
