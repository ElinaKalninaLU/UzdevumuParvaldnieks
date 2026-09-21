using System;
using System.Collections.Generic;
using System.Text;

namespace UzdevumuParvaldnieksMAUI.ViewModel
{
    public interface IEditUzdevumsViewModel
    {
        bool VaiEdit { get; set; }

        String Nosaukums { get; set; }

        String Apraksts { get; set; }
        int Id { get; set; }

        bool VaiAtkartojas { get; set; }

        AtkartosanasBiezumsEnum AtkartosanasBiezums { get; set; }

        DateTime Termins { get; set; }

        bool VaiIrIzpildits { get; set; }
    }
}
