using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GuildWars2.Models
{

	public class DetailAchievementModel
	{
		public int id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("requirement")]
		public string Requirement { get; set; }
		[JsonProperty("locked_text")]
		public string LockedText { get; set; }
		[JsonProperty("type")]
		public string Type { get; set; }
		[JsonProperty("flags")]
		public List<string> Flags { get; set; }
		[JsonProperty("tiers")]
		public List<Tier> Tiers { get; set; }
		[JsonProperty("rewards")]
		public List<Reward> Rewards { get; set; }
		[JsonProperty("bits")]
		public List<Bit> Bits { get; set; }
	}

	public class Tier
	{
		public int count { get; set; }
		public int points { get; set; }
	}

	public class Reward
	{
		public string type { get; set; }
		public int id { get; set; }
		public int count { get; set; }
		public string region { get; set; }
	}

	public class Bit
	{
		public string type { get; set; }
		public int id { get; set; }
	}
}
