using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using UzdevumuParvaldnieksKlases;
using UzdevumuParvaldnieksTestData;

namespace UzdevumuTestData
{
    public class TestDataFactoryList : ITestDataFactory, ISaveLoad
    {
        private List<Uzdevums> testData;

        private string fileName = "test_data.json";
            public string FileName { get => fileName; set => fileName = value; }

            public void CreateTestData()
        {
            testData = new List<Uzdevums>();
            if (!File.Exists(FileName))
            {
                testData.Add(new Uzdevums(1, "Pirmais uzdevums", "Apraksts par pirmo uzdevumu"));
                testData.Add(new Uzdevums(2, "Otrais uzdevums", "Apraksts par otro uzdevumu"));

                SaveToFile();
            }
            else
            {
                LoadFromFile();
            }
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
            if (testData == null)
            {
                CreateTestData();
            }
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

        public bool AddTestData(Uzdevums uzd)
        {
            testData.Add(uzd);
            SaveToFile();
            return true;
        }

        public bool UpdateTestData(Uzdevums uzd)
        {
            Uzdevums u1 = testData.Where(u => u.ID == uzd.ID).First();
            if (u1 != null)
            {
                u1.Nosaukums = uzd.Nosaukums;
                u1.Apraksts = uzd.Apraksts;
                SaveToFile();
                return true;
            }
            return false;
        }

        public bool DeleteTestData(Uzdevums uzd)
        {

            bool result = testData.Remove(uzd);
            if (result)
            {
                SaveToFile();
            }
            return result;
        }

        public Uzdevums GetTestDataItem(int id)
        {
            if (testData == null)
            {
                CreateTestData();
            }
            return testData.FirstOrDefault(u => u.ID == id);
        }
    }
}
