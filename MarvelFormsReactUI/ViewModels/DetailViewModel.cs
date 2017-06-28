

using MarvelFormsReactUI.Core.Services;
using ReactiveUI;
using Splat;

namespace MarvelFormsReactUI.ViewModels
{
	public class DetailViewModel : ViewModelBase
	{
		private readonly IOpenWebService _openWebService;

        public ReactiveCommand OpenWeb { get; protected set; }
        public CharacterItemViewModel Character { get; protected set; }

		public DetailViewModel (CharacterItemViewModel character,
                                IOpenWebService openWebService = null)
		{
			Character = character;
            _openWebService = openWebService ?? Locator.Current.GetService<IOpenWebService>();

            OpenWeb = ReactiveCommand.Create(() => _openWebService.OpenUrl(Character.Thumbnail));
		}

		


	}
}

