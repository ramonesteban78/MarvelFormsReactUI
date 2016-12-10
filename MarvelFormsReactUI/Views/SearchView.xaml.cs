using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using MarvelFormsReactUI.ViewModels;
using ReactiveUI;
using ReactiveUI.XamForms;
using Xamarin.Forms;

namespace MarvelFormsReactUI
{
	public partial class SearchView : ReactiveContentPage<SearchViewModel>
	{

		public SearchView()
		{
			InitializeComponent();

			// Bindings
			this.WhenActivated((CompositeDisposable disposables) =>
			{
				// Search text
				this.Bind(ViewModel, 
				          vm => vm.SearchText, 
				          view => view.searchCharacters.Text)
				    .DisposeWith(disposables);

				// CharacterList
				this.OneWayBind(ViewModel, 
				                vm => vm.Characters, 
				                view => view.listCharacters.ItemsSource)
				    .DisposeWith(disposables);

				// Selected character
				this.Bind(ViewModel, 
				          vm => vm.SelectedItem, 
				          view => view.listCharacters.SelectedItem)
				    .DisposeWith(disposables);

				this.WhenAnyValue(x => x.ViewModel.IsLoading)
				    .Subscribe(isBusy =>
					{
						activityLoading.IsVisible = isBusy;
						activityLoading.IsRunning = isBusy;
					})
				    .DisposeWith(disposables);
			});
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			// Informamos el viewmodel y lo asignamos al datacontext
			ViewModel.SelectedItem = null;


		}
	}
}
