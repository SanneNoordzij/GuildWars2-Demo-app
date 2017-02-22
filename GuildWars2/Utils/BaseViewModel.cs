using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace GuildWars2.Utils
{
	public class BaseViewModel : INotifyPropertyChanged, IDisposable
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private bool _IsBusy;

		public bool IsBusy
		{
			get
			{
				return _IsBusy;
			}
			set
			{
				if (_IsBusy != value)
				{
					_IsBusy = value;
					OnPropertyChanged("IsBusy");
				}
			}
		}

		public void Dispose()
		{
			ClearEvents();
		}

		protected bool ProcPropertyChanged<T>(ref T currentValue, T newValue, [CallerMemberName] string propertyName = "")
		{
			return PropertyChanged.SetProperty(this, ref currentValue, newValue, propertyName);
		}
		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}


		public virtual void ClearEvents()
		{
			var invocation = PropertyChanged?.GetInvocationList() ?? new Delegate[0];
			foreach (var p in invocation)
				PropertyChanged -= (PropertyChangedEventHandler)p;
		}
	}
}
