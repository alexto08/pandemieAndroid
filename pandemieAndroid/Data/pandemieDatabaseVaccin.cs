using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using pandemieAndroid.Models;
using Microsoft.EntityFrameworkCore;

namespace pandemieAndroid.Data
{
    public class pandemieDatabaseVaccin
    {
        VaccinIRestService restService;
        public pandemieDatabaseVaccin(VaccinIRestService service)
        {
            restService = service;
        }
        public Task<List<Vaccin>> GetVaccinAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task SaveVaccinAsync(Vaccin item, bool isNewItem = true)
        {
            return restService.SaveVaccinAsync(item, isNewItem);
        }
        public Task DeleteVaccinAsync(Vaccin item)
        {
            return restService.DeleteVaccinAsync(item.ID);
        }

        

    }

}
