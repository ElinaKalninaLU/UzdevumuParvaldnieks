using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using UzdevumuParvaldnieksKlases;
using UzdevumuParvaldnieksMAUIApp.Views;
using UzdevumuTestData;

namespace UzdevumuParvaldnieksMAUIApp.ViewModels
{
    public partial class UzdevumuSarakstsViewModel : ObservableObject, IUzdevumuSarakstsViewModel
    {
        public UzdevumuSarakstsViewModel(ITestDataFactory tdf)
        {
            testDataFactory = tdf;
            tdf.CreateTestData();
            Uzdevumi = new ObservableCollection<Uzdevums>(tdf.GetTestData());
        }
        private ITestDataFactory testDataFactory;

        [ObservableProperty]
        private ObservableCollection<Uzdevums> uzdevumi;
        IEnumerable<Uzdevums> IUzdevumuSarakstsViewModel.Uzdevumi { get => Uzdevumi; set => throw new NotImplementedException(); }

        [RelayCommand] public void PievienotUzdevumu()
        {
            int jaunsId = Uzdevumi.Count == 0
        ? 1
        : Uzdevumi.Max(x => x.ID) + 1;

            var uzdevums = new Uzdevums(jaunsId, "Trešais uzdevums", "Apraksts par trešo uzdevumu");
            testDataFactory.AddTestData(uzdevums);
            Uzdevumi.Add(uzdevums);
        }

        [RelayCommand]
        public async void LabotUzdevumu(Uzdevums uzd)
        {
            if (uzd is null)
                return;

            await Shell.Current.Navigation.PushAsync(
                new UzdevumsView(uzd, testDataFactory));
         //   throw new NotImplementedException("UzdevumsView nav izveidots, tāpēc šī funkcionalitāte nav pieejama.");


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

            if (testDataFactory.DeleteTestData(uzdevums))
            {
                Uzdevumi.Remove(uzdevums);
            }
        }

        public void Ieladet()
        {
            var dati = testDataFactory.GetTestData();

            Uzdevumi = new ObservableCollection<Uzdevums>(dati);
        }
    }
}
