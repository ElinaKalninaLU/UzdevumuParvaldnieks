using System;
using System.Collections.Generic;
using System.Text;

namespace UzdevumuParvaldnieksMAUI.Data
{
    public interface IDataProvider
    {
        IEnumerable<Uzdevums> GetUzdevums();

        bool AddUzdevums(Uzdevums uzd);

        bool UpdateUzdevums(Uzdevums uzd);

        bool DeleteUzdevums(Uzdevums uzd);
    }
}
