using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using GuildWars2.iOS.CustomRenderers;
using UIKit;
using GuildWars2.CustomViews;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace GuildWars2.iOS.CustomRenderers
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
					Control.Layer.BorderColor = custromEntry.BorderColor.ToCGColor();
					Control.Layer.BorderWidth = 1;
					Control.Layer.CornerRadius = 4;
				}
			}
		}
	}
}
