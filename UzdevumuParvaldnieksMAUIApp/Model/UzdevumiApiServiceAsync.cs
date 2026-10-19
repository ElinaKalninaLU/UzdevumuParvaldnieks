using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using UzdevumuParvaldnieksKlases;


namespace UzdevumuParvaldnieksMAUIApp.Model
{
    public class UzdevumiApiServiceAsync : ITestDataFactoryAsync

    {
        private readonly HttpClient _http;

        public UzdevumiApiServiceAsync(HttpClient http)
        {
            _http = http;
        }

        public async Task<int> AddTestDataAsync(UzdevumsDto uzd)
        {

            using var response = await _http.PostAsJsonAsync("Uzdevumi", uzd);
            response.EnsureSuccessStatusCode();

            var izveidotais = await response.Content.ReadFromJsonAsync<Uzdevums>();

            if (izveidotais is null)
                throw new InvalidOperationException("API neatgrieza izveidoto uzdevumu.");

            return izveidotais.ID;
        }

        public void CreateTestData()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteTestDataAsync(UzdevumsDto uzd)
        {
            return await DeleteTestDataAsync(uzd.ID);
        }

        public async Task<bool> DeleteTestDataAsync(int ID)
        {
            var response = await _http.DeleteAsync($"Uzdevumi/{ID}");
            return response.IsSuccessStatusCode;
        }

        public async Task<IReadOnlyList<UzdevumsDto>> GetTestDataAsync()
        {
            try
            {
                var response = await _http.GetAsync("Uzdevumi");
                var json = await response.Content.ReadAsStringAsync();

                response.EnsureSuccessStatusCode();

                var dati = JsonSerializer.Deserialize<List<UzdevumsDto>>(json)
                           ?? new List<UzdevumsDto>();

                Debug.WriteLine($"Saņemto uzdevumu skaits: {dati.Count}");

                return dati;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"GetTestDataAsync kļūda: {ex}");
                throw;
            }
        }

        async public Task<UzdevumsDto?> GetTestDataItemAsync(int id)
        {
            using var response = await _http.GetAsync($"Uzdevumi/{id}");

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<UzdevumsDto>();
        }

        public async Task<string> ReturnTestData()
        {
            var dati = await GetTestDataAsync();
            return JsonSerializer.Serialize(dati);
        }

        public async Task<bool> UpdateTestDataAsync(UzdevumsDto uzd)
        {
            using var response = await _http.PutAsJsonAsync($"Uzdevumi/{uzd.ID}", uzd);
            return response.IsSuccessStatusCode;
        }
    }
}
