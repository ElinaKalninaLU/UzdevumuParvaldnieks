using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using UzdevumuParvaldnieksKlases;

namespace UzdevumParvaldnieksSQLite
{
    public class UzdevumsDB
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(100)]
        public string Nosaukums { get; set; }

        [MaxLength(100)]
        public string Apraksts { get; set; }

        public UzdevumsDB() { }

        public UzdevumsDB(Uzdevums uzd)
        {
            ID = uzd.ID;
            Nosaukums = uzd.Nosaukums;
            Apraksts = uzd.Apraksts;
        }

        public UzdevumsDB(string nosaukums, string apraksts)
        {
            Nosaukums = nosaukums;
            Apraksts = apraksts;
        }

    }
}
