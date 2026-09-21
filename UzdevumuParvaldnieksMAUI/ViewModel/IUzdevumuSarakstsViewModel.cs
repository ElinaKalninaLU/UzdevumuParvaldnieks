using System;
using System.Collections.Generic;
using System.Text;

namespace UzdevumuParvaldnieksMAUI.ViewModel
{
    public interface IUzdevumuSarakstsViewModel
    {
        public IEnumerable<Uzdevums> UzdevumuSaraksts { get; }

       public string Text { get; }

    }
}
