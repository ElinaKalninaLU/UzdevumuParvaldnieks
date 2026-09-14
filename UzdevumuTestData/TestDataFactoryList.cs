using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using UzdevumuParvaldnieksKlases;

namespace UzdevumuTestData
{
    public class TestDataFactoryList : ITestDataFactory, ISaveLoad
    {
        private List<Uzdevums> testData;

        private string fileName;
            public string FileName { get => fileName; set => fileName = value; }

            public void CreateTestData()
        {
            testData = new List<Uzdevums>();
            testData.Add(new Uzdevums(1, "Pirmais uzdevums", "Apraksts par pirmo uzdevumu"));
            testData.Add(new Uzdevums(2, "Otrais uzdevums", "Apraksts par otro uzdevumu"));
        }

        public string ReturnTestData()
        {
            string s = "List" + "\n";
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

        public bool SaveToFile()
        {
            string jsonString = JsonSerializer.Serialize(testData);
            File.WriteAllText(FileName, jsonString);
            return true;
        }

        public bool LoadFromFile()
        {
            if (File.Exists(FileName))
            {
                string jsonString = File.ReadAllText(FileName);
                testData = JsonSerializer.Deserialize<List<Uzdevums>>(jsonString);

            }
            return true;
        }
    }
}
