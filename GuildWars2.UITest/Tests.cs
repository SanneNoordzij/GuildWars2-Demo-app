using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace GuildWars2.UITest
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
		}

		[Test]
		public void AppLaunches()
		{
			app.Screenshot("First screen.");
		}

		[Test]
		public void NoEntryTextLoginButton()
		{
			app.EnterText("apiKeyEntry", "");
			var objectsQuery = app.Query(c => c.Button("loginbutton"));
			var button = objectsQuery.First();
			Assert.IsFalse(button.Enabled, "Button is enable when it should not be enabled");
			app.Screenshot("No Text");
		}
		[Test]
		public void InvalidEntryTextLoginButton()
		{
			app.EnterText("apiKeyEntry", "2321321231231");
			var objectsQuery = app.Query(c => c.Button("loginbutton"));
			var button = objectsQuery.First();
			Assert.IsFalse(button.Enabled, "Button is enable when it should not be enabled");
			app.Screenshot("Invalid Text");
		}
		[Test]
		public void ValidEntryTextLoginButton()
		{
			app.EnterText("apiKeyEntry", "232-1321231231");
			var objectsQuery = app.Query(c => c.Button("loginbutton"));
			var button = objectsQuery.First();
			Assert.IsTrue(button.Enabled, "Button is not enable when it should be enabled");
			app.Screenshot("Valid Text");
		}
	}
}
