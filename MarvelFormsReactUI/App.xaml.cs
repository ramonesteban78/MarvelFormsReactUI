using System;
using MarvelFormsReactUI.Core.Services;
using Splat;
using Xamarin.Forms;

namespace MarvelFormsReactUI
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			var appBootstrapper = new AppBootstrapper();
			var navpage = (NavigationPage)appBootstrapper.CreateMainPage();
			navpage.BarBackgroundColor = Color.FromHex("#D32F2F");
			navpage.BarTextColor = Color.White;

			MainPage = navpage;
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
