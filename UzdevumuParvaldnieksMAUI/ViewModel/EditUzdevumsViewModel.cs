using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using UzdevumuParvaldnieksMAUI.Data;

namespace UzdevumuParvaldnieksMAUI.ViewModel
{
    public partial class EditUzdevumsViewModel : ObservableObject, IEditUzdevumsViewModel
    {
        private IDataProvider _idp;
        public EditUzdevumsViewModel(IDataProvider idp) {
            vaiEdit = false;
            _idp = idp;
            atkartosanasBiezumsList = new ObservableCollection<string>(Enum.GetValues(typeof(AtkartosanasBiezumsEnum)).OfType<AtkartosanasBiezumsEnum>().Select(x => x.ToString()).ToList());
        }

        [ObservableProperty]
        private bool vaiEdit = false;

        [ObservableProperty]
        private string nosaukums;

        [ObservableProperty]
        private string apraksts;

        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private bool vaiAtkartojas;

        [ObservableProperty]
        private AtkartosanasBiezumsEnum atkartosanasBiezums;
        private ObservableCollection<string> atkartosanasBiezumsList;

        [ObservableProperty]
        private DateTime termins;

        [ObservableProperty]
        private bool vaiIrIzpildits;

        [RelayCommand] 
        private void Pievienot()
        {
           var uzdevums = new VienreizejsUzdevums()
           {
               Nosaukums = this.Nosaukums,
               Apraksts = this.Apraksts,
               Termins = this.Termins,
               VaiIrIzpildits = this.VaiIrIzpildits
           };
            _idp.AddUzdevums(uzdevums);
        }
    }
}
