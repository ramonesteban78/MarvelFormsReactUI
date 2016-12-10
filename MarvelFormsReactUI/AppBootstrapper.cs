using System;
using MarvelFormsReactUI.Core.Services;
using MarvelFormsReactUI.ViewModels;
using ReactiveUI;
using ReactiveUI.XamForms;
using Splat;
using Xamarin.Forms;

namespace MarvelFormsReactUI
{
	public class AppBootstrapper : ReactiveObject, IScreen
	{
		public AppBootstrapper()
		{
			// IScreen 
			Locator.CurrentMutable.RegisterConstant(this, typeof(IScreen));

			// Services
			Locator.CurrentMutable.RegisterLazySingleton(() => new MarvelApiService(), typeof(IMarvelApiService));

			// Views and ViewModels
			Locator.CurrentMutable.RegisterLazySingleton(() => new SearchView(), typeof(IViewFor<SearchViewModel>));
			Locator.CurrentMutable.RegisterLazySingleton(() => new DetailView(), typeof(IViewFor<DetailViewModel>));
			Locator.CurrentMutable.RegisterLazySingleton(() => new CharacterItemViewModel(), typeof(IViewFor<CharacterCell>));

			// Routing
			Router = new RoutingState();
			Router.NavigationStack.Add(new SearchViewModel());
		}

		public RoutingState Router
		{
			get;
			protected set;
		}

		public Page CreateMainPage()
		{
			// NB: This returns the opening page that the platform-specific
			// boilerplate code will look for. It will know to find us because
			// we've registered our AppBootstrapper as an IScreen.
			return new RoutedViewHost();
		}
	}
}
