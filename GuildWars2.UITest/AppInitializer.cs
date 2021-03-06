﻿using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace GuildWars2.UITest
{
	public class AppInitializer
	{
		public static IApp StartApp(Platform platform)
		{
			if (platform == Platform.Android)
			{
				return ConfigureApp
					.Android
					.EnableLocalScreenshots()
					.ApkFile("/Demo/com.companyname.guildwars2.apk")
					.StartApp();
			}

			return ConfigureApp
				.iOS
				.EnableLocalScreenshots()
				.AppBundle("../../../iOS/bin/iPhoneSimulator/Debug/GuildWars2.iOS.app")
				.StartApp();
		}
	}
}
