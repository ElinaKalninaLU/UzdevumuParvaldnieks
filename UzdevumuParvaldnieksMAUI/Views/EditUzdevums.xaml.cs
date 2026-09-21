using UzdevumuParvaldnieksMAUI.ViewModel;
namespace UzdevumuParvaldnieksMAUI.Views;

public partial class EditUzdevums : ContentPage
{
	public EditUzdevums()
	{
		InitializeComponent();
	}

	public EditUzdevums(IEditUzdevumsViewModel vm) : this()
    {
        BindingContext = vm;
    }
}