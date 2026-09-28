using System;
using System.Collections.Generic;
using System.Text;
using UzdevumuParvaldnieksKlases;

namespace UzdevumuParvaldnieksMAUIApp.ViewModels
{
    public interface IUzdevumuSarakstsViewModel
    {
        public  IEnumerable<Uzdevums> Uzdevumi { get; set; }
    }
}
