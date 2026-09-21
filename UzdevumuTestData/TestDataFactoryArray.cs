using System;
using System.Collections.Generic;
using System.Text;
using UzdevumuParvaldnieksKlases;

namespace UzdevumuTestData
{
    public class TestDataFactoryArray : ITestDataFactory
    {
        private Uzdevums[] testData;
        private int uzdCount = 0;
        public void CreateTestData()
        {
            testData = new Uzdevums[10];
            testData[0] = new Uzdevums(1, "Pirmais uzdevums", "Apraksts par pirmo uzdevumu");
            testData[1] = new Uzdevums(2, "Otrais uzdevums", "Apraksts par otro uzdevumu");
            uzdCount = 2;
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

        public bool AddTestData(Uzdevums uzd)
        {
            if (uzdCount < testData.Length)
            {
                testData[uzdCount] = uzd;
                uzdCount++;
                return true;
            }
            return false;
        }

        public bool UpdateTestData(Uzdevums uzd)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTestData(Uzdevums uzd)
        {
            throw new NotImplementedException();
        }
    }
}
