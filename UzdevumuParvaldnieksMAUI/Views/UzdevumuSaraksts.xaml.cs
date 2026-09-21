using UzdevumuParvaldnieksMAUI.ViewModel;
using UzdevumuTestData;

namespace UzdevumuParvaldnieksMAUI.Views;

public partial class UzdevumuSaraksts : ContentPage
{
	public UzdevumuSaraksts()
	{
		InitializeComponent();
        // lblText.Text = "Sveiki, šis ir uzdevumu saraksts!";
        //ITestDataFactory testDataFactory = new TestDataFactoryList();
        //testDataFactory.CreateTestData();
        //lblText.Text = testDataFactory.ReturnTestData();

    }

    IUzdevumuSarakstsViewModel _vm;

    public UzdevumuSaraksts (IUzdevumuSarakstsViewModel vm) : this()
    {
        BindingContext = vm;
        lblText.Text = vm.Text;
        _vm = vm;
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        this.BindingContext = null;
        BindingContext = _vm;
    }

    //public UzdevumuSaraksts(ITestDataFactory tdf)
    //{
    //    InitializeComponent();
    //tdf.CreateTestData();
    // lblText.Text = tdf.ReturnTestData();
    //}

}