using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace GuildWars2.Models
{

	public class DailyAchievementModel
	{
		[JsonProperty("pve")]
		public List<DailyAchievementSummaryModel> PvE { get; set; }
		[JsonProperty("pvp")]
		public List<DailyAchievementSummaryModel> PvP { get; set; }
		[JsonProperty("wvw")]
		public List<DailyAchievementSummaryModel> WvW { get; set; }
	}

	public class DailyAchievementSummaryModel
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("level")]
		public LevelModel Level { get; set; }
		[JsonProperty("required_access")]
		public List<string> RequiredAccess { get; set; }
	}

	public class LevelModel
	{
		public int min { get; set; }
		public int max { get; set; }
	}
}
