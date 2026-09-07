using System;
using System.Collections.Generic;
using System.Text;

namespace UzdevumuParvaldnieksKlases
{
    public class VienreizejsUzdevums : Uzdevums
    {
        public DateTime Termins { get; set; }
        public bool VaiIrIzpildits { get; set; } = false;

        public override string ToString()
        {
            return base.ToString() + $", Termins: {Termins}, Vai ir izpildīts: {VaiIrIzpildits}";
        }
    }
}
