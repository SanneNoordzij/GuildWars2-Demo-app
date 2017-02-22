using System;
using Xamarin.Forms;

namespace GuildWars2.CustomViews
{
	public class CustromEntry : Entry
	{
		public static readonly BindableProperty BorderColorProperty = BindableProperty.Create("BorderColor", typeof(Color), typeof(CustromEntry), defaultValue: Color.Transparent, defaultBindingMode: BindingMode.OneWay);

		public Color BorderColor
		{
			get { return (Color)GetValue(BorderColorProperty); }
			set { SetValue(BorderColorProperty, value); }
		}
	}
}
