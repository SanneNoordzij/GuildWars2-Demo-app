using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GuildWars2.Models;
using Refit;

namespace GuildWars2.API
{
	public interface IGuildWarsApi
	{
		[Get("/achievements/daily")]
		Task<DailyAchievementModel> GetDailyAchievements();

		[Get("/achievements")]
		Task<List<DetailAchievementModel>> GetDetailInformationAboutAchievements([AliasAs("ids")] string achievementIds);
	}
}
