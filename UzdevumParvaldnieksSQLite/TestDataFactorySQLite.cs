using System.Diagnostics;
using UzdevumuParvaldnieksKlases;
using UzdevumuTestData;
using SQLite;

namespace UzdevumParvaldnieksSQLite
{
    public class TestDataFactorySQLite : ITestDataFactory
    {
        public static string dbFileN = "uzdevumidb.db";
        public static string folderPath
            = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private SQLiteConnection conn;
        public static string dbPath
        {
            get
            {
                //    if (DeviceInfo.Platform.ToString() == "Android")
                //    {
                //        Debug.WriteLine(DeviceInfo.Platform);
                //        return Path.Combine(FileSystem.AppDataDirectory, dbFileN);
                //    }
                //    else
                //    {
                return Path.Combine(folderPath, dbFileN);
                //    }
            }
        }

        public bool Init()
        {
           if (conn != null) { return false; }
            try
            {
               conn = new SQLiteConnection(dbPath);
               var r = conn.CreateTable<UzdevumsDB>();
                if (conn.Table<UzdevumsDB>().Count() == 0)
                {
                    CreateTestData();
                }

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error" + ex);
                return false;
            }
        }

        public TestDataFactorySQLite()
        {
            Init();
        }
        public bool AddTestData(Uzdevums uzd)
        {
            try
            {
                var uzdDB = new UzdevumsDB(uzd);
                conn.Insert(uzdDB);
                conn.Commit();
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
                conn.Insert(new UzdevumsDB("Pirmais uzdevums", "Apraksts par pirmo uzdevumu"));
                conn.Insert(new UzdevumsDB("Otrais uzdevums", "Apraksts par otro uzdevumu"));
                conn.Commit();
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
                var uzd2 = conn.Table<UzdevumsDB>().FirstOrDefault(u => u.ID == uzd.ID);
                conn.Delete(uzd2);
                conn.Commit();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting test data from the database.", ex);
            }
        }

        public IEnumerable<Uzdevums> GetTestData()
        {
            return conn.Table<UzdevumsDB>().Select(u => new Uzdevums(u.ID, u.Nosaukums, u.Apraksts)).ToList();
        }

        public Uzdevums GetTestDataItem(int id)
        {
            return conn.Table<UzdevumsDB>().Where(u => u.ID == id).Select(u => new Uzdevums(u.ID, u.Nosaukums, u.Apraksts)).FirstOrDefault();
        }

        public string ReturnTestData()
        {
            throw new NotImplementedException();
        }

        public bool UpdateTestData(Uzdevums uzd)
        {
            try
            {
                var uzd2 = conn.Table<UzdevumsDB>().FirstOrDefault(u => u.ID == uzd.ID);
                if (uzd2 == null)
                {
                    return false; // Item not found
                }
                uzd2.Apraksts = uzd.Apraksts;
                uzd2.Nosaukums = uzd.Nosaukums;
                conn.Update(uzd2);
                conn.Commit();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating test data in the database.", ex);
            }
        }
    }
}
