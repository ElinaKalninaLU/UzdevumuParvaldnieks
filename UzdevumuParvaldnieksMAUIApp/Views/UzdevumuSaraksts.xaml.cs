using UzdevumuParvaldnieksMAUIApp.ViewModels;

namespace UzdevumuParvaldnieksMAUIApp.Views;

public partial class UzdevumuSaraksts : ContentPage
{
    private UzdevumuSarakstsViewModelAsync vm;
    public UzdevumuSaraksts(UzdevumuSarakstsViewModelAsync viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        vm = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is UzdevumuSarakstsViewModelAsync vm)
            await vm.Ieladet();
    }
}