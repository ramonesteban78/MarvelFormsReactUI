using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using MarvelFormsReactUI.ViewModels;
using ReactiveUI;
using ReactiveUI.XamForms;
using Xamarin.Forms;

namespace MarvelFormsReactUI
{
	public partial class CharacterCell : ReactiveViewCell<CharacterItemViewModel>
	{
		public CharacterCell()
		{
			InitializeComponent();

			this.WhenActivated((CompositeDisposable disposables) =>
			{
				// Binding with a converter
				this.OneWayBind(ViewModel,
								vm => vm.Thumbnail,
								cell => cell.imageThumbnail.Source,
				                (string arg) => ImageSource.FromUri(new Uri(arg)))
				    .DisposeWith(disposables);
				
				this.OneWayBind(ViewModel, vm => vm.Name, cell => cell.textName.Text)
				    .DisposeWith(disposables);
			});

		}
	}
}
