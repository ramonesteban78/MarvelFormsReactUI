using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Splat;
using MarvelFormsReactUI.Droid.Services;
using MarvelFormsReactUI.Core.Services;

namespace MarvelFormsReactUI.Droid
{
	[Activity(Label = "MarvelFormsReactUI.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

            InitAppServices();

			global::Xamarin.Forms.Forms.Init(this, bundle);

			LoadApplication(new App());
		}

        private void InitAppServices()
        {
			Locator.CurrentMutable.RegisterLazySingleton(() => new Logger(), typeof(ILogger));
			Locator.CurrentMutable.RegisterLazySingleton(() => new OpenWebService(), typeof(IOpenWebService));
        }
    }
}
