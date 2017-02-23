using System;
using GuildWars2.Models;
using GuildWars2.Utils;

namespace GuildWars2.ViewModels
{
	public class AchievementDetailViewModel : BaseViewModel
	{
		public DetailAchievementModel Model { get; private set; }

		public AchievementDetailViewModel(DetailAchievementModel model)
		{
			Model = model;
		}
	}
}
