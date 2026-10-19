using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using UzdevumuParvaldnieksKlases;
using UzdevumuTestData;
using UzdevumuParvaldnieksMAUIApp.Model;

namespace UzdevumuParvaldnieksMAUIApp.ViewModels
{
    public partial class UzdevumsViewModelAsync : ObservableObject
    {
        private ITestDataFactoryAsync testDataFactory;
        private UzdevumsDto _uzdevums;
        public UzdevumsViewModelAsync(Uzdevums uzd, ITestDataFactoryAsync tdf)
        {
            testDataFactory = tdf;
            _uzdevums = new UzdevumsDto()
            {
                ID = uzd.ID,
                Nosaukums = uzd.Nosaukums,
                Apraksts = uzd.Apraksts
            };
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
            await testDataFactory.UpdateTestDataAsync(_uzdevums);
            await Shell.Current.Navigation.PopAsync();
        }

        [RelayCommand]
        private async Task AtceltAsync()
        {
            await Shell.Current.Navigation.PopAsync();
        }


    }
}
