using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using UzdevumuParvaldnieksKlases;
using UzdevumuTestData;

namespace UzdevumuParvaldnieksMAUIApp.ViewModels
{
    public partial class UzdevumsViewModel : ObservableObject
    {
        private ITestDataFactory testDataFactory;
        private Uzdevums _uzdevums;
        public UzdevumsViewModel(Uzdevums uzd, ITestDataFactory tdf)
        {
            testDataFactory = tdf;
            _uzdevums = uzd;
            Nosaukums = uzd.Nosaukums;
            Apraksts = uzd.Apraksts;
        }

        [ObservableProperty]
        private string nosaukums;

        [ObservableProperty]
        private string apraksts;

        [RelayCommand]
        private async Task SaglabatAsync()
        {
           _uzdevums.Nosaukums = Nosaukums;
            _uzdevums.Apraksts = Apraksts;
            OnPropertyChanged();
            testDataFactory.UpdateTestData(_uzdevums);
            await Shell.Current.Navigation.PopAsync();
        }

        [RelayCommand]
        private async Task AtceltAsync()
        {
            await Shell.Current.Navigation.PopAsync();
        }


    }
}
