
using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;

namespace EntryAsPickerExample.ViewModels
{
	public class MainPageViewModel : BindableBase, INavigationAware
	{
		readonly IPageDialogService _pageDialogService;
		public DelegateCommand<bool?> FocusedCommand { get; set; }

		string _selectedaction;
		public string SelectedAction
		{
			get { return _selectedaction; }
			set { SetProperty(ref _selectedaction, value); }
		}

		string _title;
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		string _placeholderTitle;
		public string PlaceholderTitle
		{
			get { return "Pressione aqui"; }
			set { SetProperty(ref _placeholderTitle, value); }
		}

		public Action<bool?> FocusedAction
		{
			get
			{
				return new Action<bool?>(async (isFocused) =>
				{
					if (isFocused != null && !(bool)isFocused)
						return;

					var result = await _pageDialogService.DisplayActionSheetAsync("Meu Título"
																, "CANCELAR"
																, "LIMPAR"
																, new string[]
					{
						"Opção 1",
						"Opção 2",
						"Opção 3",
						"Opção 1",
						"Opção 2",
						"Opção 3",
						"Opção 1",
						"Opção 2",
						"Opção 3",
						"Opção 1",
						"Opção 2",
						"Opção 3",
						"Opção 1",
						"Opção 2",
						"Opção 3",
						"Opção 1",
						"Opção 2",
						"Opção 3",
						"Opção 1",
						"Opção 2",
						"Opção 3",
						"Opção 1",
						"Opção 2",
						"Opção 3",
						"Opção 1",
						"Opção 2",
						"Opção 3",
						"Opção 1",
						"Opção 2",
						"Opção 3",
						"Opção 2",
						"Opção 3",
						"Opção 2",
						"Opção 3",
						"Opção 4"
					});

					if (!string.IsNullOrEmpty(result) && result != "CANCELAR" && result != "LIMPAR")
						SelectedAction = result;

					if (!string.IsNullOrEmpty(result) && result != "CANCELAR" && result == "LIMPAR")
						SelectedAction = string.Empty;
				});
			}
		}

		public MainPageViewModel(IPageDialogService pageDialogService)
		{
			_pageDialogService = pageDialogService;
			FocusedCommand = new DelegateCommand<bool?>(FocusedAction);
		}

		public void OnNavigatedFrom(NavigationParameters parameters)
		{
		}

		public void OnNavigatedTo(NavigationParameters parameters)
		{
			if (parameters.ContainsKey("title"))
				Title = (string)parameters["title"] + " and Prism";
		}
	}
}

