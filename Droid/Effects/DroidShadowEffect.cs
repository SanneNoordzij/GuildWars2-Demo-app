using System;
using System.Linq;
using GuildWars2.Droid.Effects;
using GuildWars2.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("MyCompany")]
[assembly: ExportEffect(typeof(DroidShadowEffect), "ShadowEffect")]

namespace GuildWars2.Droid.Effects
{
	public class DroidShadowEffect : PlatformEffect
	{
		protected override void OnAttached()
		{
			try
			{
				var effect = (ShadowEffect)Element.Effects.FirstOrDefault(e => e is ShadowEffect);
				if (effect == null)
				{
					return;
				}
				float radius = effect.Radius;
				float distanceX = effect.DistanceX;
				float distanceY = effect.DistanceY;
				Android.Graphics.Color color = effect.Color.ToAndroid();

				if (Control is Android.Widget.EditText)
				{
					(Control as Android.Widget.EditText).SetShadowLayer(radius, distanceX, distanceY, color);
					return;
				}
				if (Control is Android.Widget.Button)
				{
					(Control as Android.Widget.Button).SetShadowLayer(radius, distanceX, distanceY, color);
					return;
				}
				if (Control is Android.Widget.TextView)
				{
					(Control as Android.Widget.TextView).SetShadowLayer(radius, distanceX, distanceY, color);
					return;
				}

			}
			catch (Exception ex)
			{
				Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
			}
		}

		protected override void OnDetached()
		{
		}
	}
}