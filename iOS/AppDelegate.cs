using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace GuildWars2.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			LoadApplication(new App());
			UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.LightContent;
			ZXing.Net.Mobile.Forms.iOS.Platform.Init();
			return base.FinishedLaunching(app, options);
		}
	}
}
