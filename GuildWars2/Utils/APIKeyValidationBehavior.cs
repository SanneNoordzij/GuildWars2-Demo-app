using System;
using GuildWars2.CustomViews;
using Xamarin.Forms;
using System.Linq;

namespace GuildWars2.Utils
{
	public class APIKeyValidationBehavior : Behavior<Entry>
	{

		public static readonly BindableProperty AttachBehaviorProperty =
			BindableProperty.CreateAttached("AttachBehavior", typeof(bool), typeof(APIKeyValidationBehavior), false, propertyChanged: OnAttachBehaviorChanged);

		public static bool GetAttachBehavior(BindableObject view)
		{
			return (bool)view.GetValue(AttachBehaviorProperty);
		}

		public static void SetAttachBehavior(BindableObject view, bool value)
		{
			view.SetValue(AttachBehaviorProperty, value);
		}

		static void OnAttachBehaviorChanged(BindableObject view, object oldValue, object newValue)
		{
			var entry = view as Entry;
			if (entry == null)
			{
				return;
			}

			bool attachBehavior = (bool)newValue;
			if (attachBehavior)
			{
				entry.Behaviors.Add(new APIKeyValidationBehavior());
			}
			else {
				var toRemove = entry.Behaviors.FirstOrDefault(b => b is APIKeyValidationBehavior);
				if (toRemove != null)
				{
					entry.Behaviors.Remove(toRemove);
				}
			}
		}


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
