using System;
using System.Collections.Generic;
using System.Text;
using UzdevumuParvaldnieksMAUI.Data;

namespace UzdevumuParvaldnieksMAUI.ViewModel
{
    public class UzdevumuSarakstsViewModel : IUzdevumuSarakstsViewModel
    {
        private IDataProvider _dp;
        public UzdevumuSarakstsViewModel(IDataProvider dp)
        {

            _dp = dp;
        }

        public IEnumerable<Uzdevums> UzdevumuSaraksts
        {
            get { return _dp.GetUzdevums(); }
        }

        public string Text
        {
            get { return $"Uzdevumu skaits: {UzdevumuSaraksts.Count()}"; }
        }

    }
}
