using UzdevumuParvaldnieksMAUIApp.ViewModels;

namespace UzdevumuParvaldnieksMAUIApp.Views;

public partial class UzdevumuSaraksts : ContentPage
{
    private IUzdevumuSarakstsViewModel vm;
    public UzdevumuSaraksts(IUzdevumuSarakstsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
        vm = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        vm.Ieladet();
    }
}