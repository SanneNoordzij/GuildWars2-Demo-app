using System;
using GuildWars2.CustomViews;
using Xamarin.Forms;

namespace GuildWars2.Utils
{
	public class APIKeyValidationBehavior : Behavior<Entry>
	{
		protected override void OnAttachedTo(Entry entry)
		{
			entry.TextChanged += OnEntryTextChanged;
			base.OnAttachedTo(entry);
		}

		protected override void OnDetachingFrom(Entry entry)
		{
			entry.TextChanged -= OnEntryTextChanged;
			base.OnDetachingFrom(entry);
		}

		void OnEntryTextChanged(object sender, TextChangedEventArgs args)
		{
			bool isValid = false;
			if (!string.IsNullOrEmpty(args.NewTextValue) && args.NewTextValue.Length > 10 && args.NewTextValue.Contains("-"))
			{
				isValid = true;
			}
			((Entry)sender).TextColor = isValid ? Color.Green : Color.Red;
			if (sender is CustomEntry)
			{
				((CustomEntry)sender).IsValid = isValid;
			}
		}
	}
}
