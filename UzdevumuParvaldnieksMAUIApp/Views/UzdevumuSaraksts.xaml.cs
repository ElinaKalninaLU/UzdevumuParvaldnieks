using UzdevumuParvaldnieksMAUIApp.ViewModels;

namespace UzdevumuParvaldnieksMAUIApp.Views;

public partial class UzdevumuSaraksts : ContentPage
{
	public UzdevumuSaraksts(IUzdevumuSarakstsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}