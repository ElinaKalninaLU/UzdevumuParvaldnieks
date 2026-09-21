using System;
using System.Collections.Generic;
using System.Text;

namespace UzdevumuParvaldnieksMAUI.Data
{
    public class TestDataprovider : IDataProvider
    {
        private ITestDataFactory _tdf;
        public TestDataprovider(ITestDataFactory tdf)
        {
            _tdf = tdf;
            _tdf.CreateTestData();
        }

        public bool AddUzdevums(Uzdevums uzd)
        {
            return _tdf.AddTestData(uzd);
        }

        public bool DeleteUzdevums(Uzdevums uzd)
        {
            return _tdf.DeleteTestData(uzd);
        }

        public IEnumerable<Uzdevums> GetUzdevums()
        {
            return _tdf.GetTestData();
        }

        public bool UpdateUzdevums(Uzdevums uzd)
        {
            return _tdf.UpdateTestData(uzd);
        }
    }
}
