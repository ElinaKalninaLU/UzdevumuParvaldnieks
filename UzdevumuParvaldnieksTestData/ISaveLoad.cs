using System;
using System.Collections.Generic;
using System.Text;

namespace UzdevumuParvaldnieksTestData
{
    public interface ISaveLoad
    {
        string FileName { get; set; }

        bool SaveToFile();

        bool LoadFromFile();
    }
}
