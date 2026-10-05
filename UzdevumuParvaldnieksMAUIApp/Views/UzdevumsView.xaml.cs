using UzdevumuParvaldnieksKlases;
using UzdevumuParvaldnieksMAUIApp.ViewModels;
using UzdevumuTestData;

namespace UzdevumuParvaldnieksMAUIApp.Views;

public partial class UzdevumsView : ContentPage
{
	public UzdevumsView(Uzdevums uzd, ITestDataFactory tdf)
	{
		InitializeComponent();
        BindingContext = new UzdevumsViewModel(uzd, tdf);
    }
}