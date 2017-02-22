using System;
using Android.Graphics;
using GuildWars2.CustomViews;
using GuildWars2.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace GuildWars2.Droid.CustomRenderers
{
	public class CustomEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);
			if (Control != null && e.OldElement == null)
			{
				var custromEntry = e.NewElement as CustomEntry;
				if (custromEntry != null)
				{
					Control.Background.SetColorFilter(custromEntry.BorderColor.ToAndroid(), PorterDuff.Mode.SrcIn);
				}
			}
		}
	}
}
