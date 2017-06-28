using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using MarvelFormsReactUI.Core.Services;
using MarvelFormsReactUI.iOS.Services;
using Splat;
using UIKit;

namespace MarvelFormsReactUI.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			InitAppServices();

			LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}


		private void InitAppServices()
		{
			Locator.CurrentMutable.RegisterLazySingleton(() => new Logger(), typeof(ILogger));
            Locator.CurrentMutable.RegisterLazySingleton(() => new OpenWebService(), typeof(IOpenWebService));
		}
	}
}
