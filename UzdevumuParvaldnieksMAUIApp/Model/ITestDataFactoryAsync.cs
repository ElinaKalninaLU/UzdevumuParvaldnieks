using System;
using System.Collections.Generic;
using System.Text;

namespace UzdevumuParvaldnieksMAUIApp.Model
{
    public interface ITestDataFactoryAsync
    {
        Task<IReadOnlyList<UzdevumsDto>> GetTestDataAsync();
        Task<int> AddTestDataAsync(UzdevumsDto uzd);
        Task<bool> DeleteTestDataAsync(int id);
        Task<UzdevumsDto?> GetTestDataItemAsync(int id);
        Task<bool> UpdateTestDataAsync(UzdevumsDto uzd);
    }
}
