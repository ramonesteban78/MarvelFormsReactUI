using System.Linq;
using System.Threading.Tasks;
using ReactiveUI;
using Splat;
using System.Reactive.Linq;
using System;
using System.Reactive.Disposables;
using MarvelFormsReactUI.Core.Services;
using System.Collections.Generic;
using System.ComponentModel;

namespace MarvelFormsReactUI.ViewModels
{
	public class SearchViewModel : ViewModelBase
    {
		private readonly IMarvelApiService _marvelService;

		public SearchViewModel (IMarvelApiService marvelService = null)
		{
			_marvelService = marvelService ?? 
                Locator.Current.GetService<IMarvelApiService>();

			UrlPathSegment = "Marvel Characters Search";

			Characters = new ReactiveList<CharacterItemViewModel>(); // Create the collection

			// Commamds
			this.SearchCharacters = ReactiveCommand.CreateFromTask<string>(
				(text) => LoadData(text))
				.DisposeWith(this.disposables);

			// Search text and InvokeCommand
			this.WhenAnyValue(x => x.SearchText)
			    .Select (x => x?.Trim())
			    .Throttle(TimeSpan.FromSeconds(1))
			    .DistinctUntilChanged()
			    .ObserveOn(RxApp.MainThreadScheduler)
			    .InvokeCommand(SearchCharacters)	
			    .DisposeWith(this.disposables);
			
			// Loading flag
			this.SearchCharacters.IsExecuting
				.ToProperty(this, x => x.IsLoading, out _IsLoading)
			    .DisposeWith(this.disposables);

			// Handle erros
			this.SearchCharacters.ThrownExceptions
			    .Subscribe ((obj) => this.LogException(obj, "Error while getting Marvel characters"))
			    .DisposeWith(this.disposables);


			// Selected Item and navigation
			this.WhenAnyValue(x => x.SelectedItem)
			    .Where(x => x != null)
			    .Subscribe (x => NavigateToDetailPage(x))
			    .DisposeWith(this.disposables);
		}

		// Properties

		#region SearchText

		private string _SearchText;
		public string SearchText
		{
			get { return _SearchText; }
			set { this.RaiseAndSetIfChanged(ref _SearchText, value); }
		}

		#endregion

		#region Characters

		private ReactiveList<CharacterItemViewModel> _Characters;
		public ReactiveList<CharacterItemViewModel> Characters
		{
			get { return _Characters; }
			set { this.RaiseAndSetIfChanged(ref _Characters, value); }
		}

		#endregion

		#region IsLoading
		protected ObservableAsPropertyHelper<bool> _IsLoading;
		public bool IsLoading
		{
			get { return _IsLoading.Value; }
		}
		#endregion

		#region SelectedItem

		private CharacterItemViewModel _SelectedItem;
		public CharacterItemViewModel SelectedItem
		{
			get { return this._SelectedItem; }
			set { this.RaiseAndSetIfChanged(ref _SelectedItem, value); }
		}

		#endregion

		// Commands
		public ReactiveCommand SearchCharacters { get; protected set; }


		// Private methods

		private async Task LoadData(string filter = null, int limit = 0, int offset = 0)
		{
			var result = await _marvelService.GetCharacters(filter, limit, offset);
			if (result != null)
			{
				var characters = (from p in result.Results
								  select new CharacterItemViewModel()
								  {
									  Id = p.Id,
									  Name = p.Name,
									  Thumbnail = p.Thumbnail.Path + "." + p.Thumbnail.Extension,
									  Description = p.Description
								  });

				//// Inform our collection
				if (characters.Any())
				{
					// Solo añadimos los que no están en la collección
					Characters = new ReactiveList<CharacterItemViewModel>(characters);
				}
				else
				{
					Characters = new ReactiveList<CharacterItemViewModel>();
				}
			}
		}

		void NavigateToDetailPage(CharacterItemViewModel item)
		{
			HostScreen.Router.Navigate.Execute(new DetailViewModel(item)).Subscribe();
		}
	}
}
