using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using GuildWars2.iOS.CustomRenderers;
using UIKit;

[assembly: ExportRenderer(typeof(Button), typeof(CustomButtonRenderer))]
namespace GuildWars2.iOS.CustomRenderers
{
	public class CustomButtonRenderer : ButtonRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				//Control.SetTitleColor(UIColor.LightGray, UIControlState.Disabled);
			}
		}
	}
}
