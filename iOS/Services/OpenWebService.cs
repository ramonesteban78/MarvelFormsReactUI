using System;
using UIKit;
using Foundation;
using MarvelFormsReactUI.iOS.Services;
using MarvelFormsReactUI.Core.Services;

namespace MarvelFormsReactUI.iOS.Services
{
	public class OpenWebService : IOpenWebService
	{
		public OpenWebService ()
		{
		}

		#region IOpenWebService implementation

		public void OpenUrl (string url)
		{
			UIApplication.SharedApplication.OpenUrl(new NSUrl(url));
		}

		#endregion
	}
}

