using System;
using System.Collections.Generic;
using System.Text;
using UzdevumuParvaldnieksKlases;

namespace UzdevumuTestData
{
    public class TestDataFactoryArray : ITestDataFactory
    {
        private Uzdevums[] testData;
        public void CreateTestData()
        {
            testData = new Uzdevums[2];
            testData[0] = new Uzdevums(1, "Pirmais uzdevums", "Apraksts par pirmo uzdevumu");
            testData[1] = new Uzdevums(2, "Otrais uzdevums", "Apraksts par otro uzdevumu");
        }

        public string ReturnTestData()
        {
            string s = "Array"+ "\n";
            foreach (var uzdevums in testData)
            {
                s += uzdevums.ToString() + "\n";
            }
            return s;
        }

        public IEnumerable<Uzdevums> GetTestData()
        {
            return testData;
        }
    }
}
