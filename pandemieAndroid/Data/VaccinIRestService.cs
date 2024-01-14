using pandemieAndroid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pandemieAndroid.Data
{
    public interface VaccinIRestService
    {
        Task<List<Vaccin>> RefreshDataAsync();
        Task SaveVaccinAsync(Vaccin item, bool isNewItem);
        Task DeleteVaccinAsync(int id);
    }
}
