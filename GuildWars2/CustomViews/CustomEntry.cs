using System;
using Xamarin.Forms;

namespace GuildWars2.CustomViews
{
	public class CustomEntry : Entry
	{
		public static readonly BindableProperty IsValidProperty = BindableProperty.Create("IsValid", typeof(bool), typeof(CustomEntry), defaultValue: false, defaultBindingMode: BindingMode.OneWay);

		public bool IsValid
		{
			get { return (bool)GetValue(IsValidProperty); }
			set { SetValue(IsValidProperty, value); }
		}

		public static readonly BindableProperty BorderColorProperty = BindableProperty.Create("BorderColor", typeof(Color), typeof(CustomEntry), defaultValue: Color.Transparent, defaultBindingMode: BindingMode.OneWay);

		public Color BorderColor
		{
			get { return (Color)GetValue(BorderColorProperty); }
			set { SetValue(BorderColorProperty, value); }
		}
	}
}
