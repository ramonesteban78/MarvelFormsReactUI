using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using MarvelFormsReactUI.ViewModels;
using ReactiveUI;
using ReactiveUI.XamForms;
using Xamarin.Forms;

namespace MarvelFormsReactUI
{
	public partial class DetailView : ReactiveContentPage<DetailViewModel>
	{
		public DetailView()
		{
			InitializeComponent();

			this.WhenActivated((disposables) =>
			{
				this.OneWayBind(ViewModel, 
				                vm => vm.Character.Thumbnail, 
				                view => view.imageThumbnail.Source, 
				                (arg) => ImageSource.FromUri(new Uri(arg)))
				    			.DisposeWith(disposables);

				this.OneWayBind(ViewModel,
								vm => vm.Character.Description,
								view => view.labelDescription.Text)
				    			.DisposeWith(disposables);

				this.OneWayBind(ViewModel,
				                vm => vm.Character.Name,
				                view => view.Title)
				    			.DisposeWith(disposables);
			});
		}
	}
}
