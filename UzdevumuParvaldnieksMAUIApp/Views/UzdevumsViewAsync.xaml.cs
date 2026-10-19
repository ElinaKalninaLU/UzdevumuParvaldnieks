using UzdevumuParvaldnieksKlases;
using UzdevumuParvaldnieksMAUIApp.ViewModels;
using UzdevumuParvaldnieksMAUIApp.Model;
using UzdevumuTestData;

namespace UzdevumuParvaldnieksMAUIApp.Views;

public partial class UzdevumsViewAsync : ContentPage
{
	public UzdevumsViewAsync(Uzdevums uzd, ITestDataFactoryAsync tdf)
	{
		InitializeComponent();
        BindingContext = new UzdevumsViewModelAsync(uzd, tdf);
    }
}