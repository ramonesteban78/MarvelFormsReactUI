using System;
using System.Reactive.Disposables;
using ReactiveUI;
using Splat;

namespace MarvelFormsReactUI.ViewModels
{
	public class ViewModelBase : ReactiveObject, 
									IDisposable, 
									IEnableLogger, 
									IRoutableViewModel
	{
		protected readonly CompositeDisposable disposables;

		#region ErrorMessage

		private string _ErrorMessage;
		public string ErrorMessage
		{
			get { return this._ErrorMessage; }
			set { this.RaiseAndSetIfChanged(ref _ErrorMessage, value); }
		}

		#endregion

		public ViewModelBase(IScreen hostScreen = null)
		{
			disposables = new CompositeDisposable();

			HostScreen = hostScreen ?? Locator.Current.GetService<IScreen>();

		}

		protected void LogException(Exception ex, string errorMessage)
		{
			this.Log().Write(ex.Message, LogLevel.Error);
			this.Log().Write(ex.StackTrace, LogLevel.Error);
			ErrorMessage = errorMessage;
		}

		public void Dispose()
		{
			disposables?.Dispose();
		}

		#region IRoutableViewModel implementation
		public string UrlPathSegment
		{
			get;
			protected set;
		}

		public IScreen HostScreen
		{
			get;
			protected set;
		}
		#endregion
	}
}
