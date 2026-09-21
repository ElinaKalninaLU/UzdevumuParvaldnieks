using System;
using System.Collections.Generic;
using System.Text;
using UzdevumuParvaldnieksKlases;

namespace UzdevumuTestData
{
    public interface ITestDataFactory
    {
        void CreateTestData();

        string ReturnTestData();

        IEnumerable<Uzdevums> GetTestData();

        bool AddTestData(Uzdevums uzd);

        bool UpdateTestData(Uzdevums uzd);

        bool DeleteTestData(Uzdevums uzd);
    }
}
