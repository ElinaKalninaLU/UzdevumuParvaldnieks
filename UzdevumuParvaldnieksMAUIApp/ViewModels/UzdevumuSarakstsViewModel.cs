using System;
using System.Collections.Generic;
using System.Text;
using UzdevumuParvaldnieksKlases;
using UzdevumuTestData;

namespace UzdevumuParvaldnieksMAUIApp.ViewModels
{
    public class UzdevumuSarakstsViewModel : IUzdevumuSarakstsViewModel
    {
        public UzdevumuSarakstsViewModel(ITestDataFactory tdf)
        {
            testDataFactory = tdf;
            tdf.CreateTestData();
        }
        private ITestDataFactory testDataFactory;
        public IEnumerable<Uzdevums> Uzdevumi { 
            get => testDataFactory.GetTestData(); 
            set => throw new NotImplementedException(); }
    }
}
