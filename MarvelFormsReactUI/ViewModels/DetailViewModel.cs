

namespace MarvelFormsReactUI.ViewModels
{
	public class DetailViewModel : ViewModelBase
	{
		//private readonly IOpenWebService _openWebService;

		public DetailViewModel (CharacterItemViewModel character)
		{
			Character = character;

			//_openWebService = DependencyService.Get<IOpenWebService> ();

			// TODO: AN. Diseñar la ventana de Detalle
		}

		public CharacterItemViewModel Character { get; protected set; }


//		#region OpenWeb Command
//
//		private ICommand _OpenWeb;
//
//		public ICommand OpenWeb {
//			get {
//				return _OpenWeb ?? (_OpenWeb = new Command (
//					ExecuteOpenWebCommand,
//					ValidateOpenWebCommand)); 
//			}
//		}
//
//		private void ExecuteOpenWebCommand ()
//		{
//			_openWebService.OpenUrl (Character.Thumbnail);
//		}
//
//		private bool ValidateOpenWebCommand ()
//		{
//			return true;
//		}
//
//		#endregion


	}
}

