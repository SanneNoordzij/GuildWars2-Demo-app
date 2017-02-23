using System;
using GuildWars2.Models;
using Xamarin.Forms;

namespace GuildWars2.CustomViews
{

	public class AchievementViewCell : ViewCell
	{
		Label TitleLabel = null;
		Label SubtitleLabel = null;

		public static readonly BindableProperty TitleProperty = BindableProperty.Create("Title", typeof(string), typeof(AchievementViewCell), "Title");
		public static readonly BindableProperty DescriptionProperty = BindableProperty.Create("Description", typeof(string), typeof(AchievementViewCell), "Description");

		public static readonly BindableProperty TitleColorProperty = BindableProperty.Create("TitleColor", typeof(Color), typeof(AchievementViewCell), Color.Black);
		public static readonly BindableProperty DescriptionColorProperty = BindableProperty.Create("DescriptionColor", typeof(Color), typeof(AchievementViewCell), Color.Black);

		public string Title
		{
			get { return (string)GetValue(TitleProperty); }
			set { SetValue(TitleProperty, value); }
		}

		public string Description
		{
			get { return (string)GetValue(DescriptionProperty); }
			set { SetValue(DescriptionProperty, value); }
		}
		public Color TitleColor
		{
			get { return (Color)GetValue(TitleColorProperty); }
			set { SetValue(TitleColorProperty, value); }
		}
		public Color DescriptionColor
		{
			get { return (Color)GetValue(DescriptionColorProperty); }
			set { SetValue(DescriptionColorProperty, value); }
		}

		public AchievementViewCell()
		{
			TitleLabel = new Label();
			SubtitleLabel = new Label();
			View = new StackLayout()
			{
				Padding = new Thickness(10),
				Children = {
					TitleLabel,
					SubtitleLabel
				}
			};
		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();

			var item = BindingContext as DetailAchievementModel;
			if (item != null)
			{
				TitleLabel.Text = Title;
				TitleLabel.TextColor = TitleColor;
				SubtitleLabel.Text = Description;
				SubtitleLabel.TextColor = DescriptionColor;
			}
		}
	}
}
