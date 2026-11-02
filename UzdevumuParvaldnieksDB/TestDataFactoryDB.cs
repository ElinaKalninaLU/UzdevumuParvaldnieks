using System;
using System.Collections.Generic;
using System.Text;
using UzdevumuParvaldnieksKlases;
using UzdevumuTestData;

namespace UzdevumuParvaldnieksDB
{
    public class TestDataFactoryDB : ITestDataFactory
    {
        private UzvevumiContext context;

        public TestDataFactoryDB(UzvevumiContext _context)
        {
            context = _context;
            if (!context.Uzdevumi.Any())
            {
                CreateTestData();
            }
        }
        public bool AddTestData(Uzdevums uzd)
        {
            try
            {
                uzd.ID = 0;
                context.Uzdevumi.Add(uzd);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating test data in the database.", ex);
            }
        }

        public void CreateTestData()
        {
            try
            {
                context.Uzdevumi.Add(new Uzdevums(0, "Pirmais uzdevums", "Apraksts par pirmo uzdevumu"));
                context.Uzdevumi.Add(new Uzdevums(0, "Otrais uzdevums", "Apraksts par otro uzdevumu"));
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating test data in the database.", ex);
            }
        }

        public bool DeleteTestData(Uzdevums uzd)
        {
            try
            {
                var uzd2 = context.Uzdevumi.FirstOrDefault(u => u.ID == uzd.ID);
                context.Uzdevumi.Remove(uzd2);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting test data from the database.", ex);
            }
        }

        public IEnumerable<Uzdevums> GetTestData()
        {
            try
            {
                return context.Uzdevumi.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving test data from the database.", ex);
            }
        }

        public Uzdevums GetTestDataItem(int id)
        {
            try
            {
                return context.Uzdevumi.FirstOrDefault(u => u.ID == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving test data item from the database.", ex);
            }
        }

        public string ReturnTestData()
        {
            string s = "List" + "\n";
            foreach (var uzdevums in GetTestData())
            {
                s += uzdevums.ToString() + "\n";
            }
            return s;
        }

        public bool UpdateTestData(Uzdevums uzd)
        {
            try
            {
                var uzd2 = context.Uzdevumi.FirstOrDefault(u => u.ID == uzd.ID);
               if (uzd2 == null)
                {
                    return false; // Item not found
                }
                uzd2.Apraksts = uzd.Apraksts;
                uzd2.Nosaukums = uzd.Nosaukums;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting test data from the database.", ex);
            }
        }
    }
}
