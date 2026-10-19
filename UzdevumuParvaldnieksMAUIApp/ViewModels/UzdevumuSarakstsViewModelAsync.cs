using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using UzdevumuParvaldnieksKlases;
using UzdevumuParvaldnieksMAUIApp.Views;
using UzdevumuTestData;
using UzdevumuParvaldnieksMAUIApp.Model;

namespace UzdevumuParvaldnieksMAUIApp.ViewModels
{
    public partial class UzdevumuSarakstsViewModelAsync : ObservableObject
    {
        public UzdevumuSarakstsViewModelAsync(ITestDataFactoryAsync tdf)
        {
            testDataFactory = tdf;
          //  tdf.CreateTestData();
            Uzdevumi = new ObservableCollection<Uzdevums>();
        }
        private ITestDataFactoryAsync testDataFactory;

        [ObservableProperty]
        private ObservableCollection<Uzdevums> uzdevumi;
      
        [RelayCommand] public async void PievienotUzdevumu()
        {
            int jaunsId = Uzdevumi.Count == 0
        ? 1
        : Uzdevumi.Max(x => x.ID) + 1;

            var uzdevums = new Uzdevums(jaunsId, "Trešais uzdevums", "Apraksts par trešo uzdevumu");
            await testDataFactory.AddTestDataAsync(new UzdevumsDto() { ID = uzdevums.ID, Nosaukums = uzdevums.Nosaukums, Apraksts = uzdevums.Apraksts });
            Uzdevumi.Add(uzdevums);
        }

        [RelayCommand]
        public async void LabotUzdevumu(Uzdevums uzd)
        {
            if (uzd is null)
                return;

            await Shell.Current.Navigation.PushAsync(
                new UzdevumsViewAsync(uzd, testDataFactory));
           }

        [RelayCommand]
        public async void DzestUzdevumu(Uzdevums uzdevums)
        {
            if (uzdevums is null)
                return;

            bool dzest = await Shell.Current.DisplayAlert(
                "Dzēst uzdevumu",
                $"Vai tiešām dzēst uzdevumu \"{uzdevums.Nosaukums}\"?",
                "Jā",
                "Nē");

            if (!dzest)
                return;

            if (await testDataFactory.DeleteTestDataAsync(uzdevums.ID))
            {
                Uzdevumi.Remove(uzdevums);
            }
        }

        public async Task Ieladet()
        {
            var dati = await testDataFactory.GetTestDataAsync();

            Uzdevumi.Clear();
            foreach (var u in dati)
                Uzdevumi.Add(new Uzdevums(u.ID, u.Nosaukums, u.Apraksts));
        }
    }
}
