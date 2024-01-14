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
    public class pandemieDatabaseAchizitie
    {
        IRestService restService;
        public pandemieDatabaseAchizitie(IRestService service)
        {
            restService = service;
        }
        public Task<List<Achizitie>> GetAchizitieAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task SaveAchizitieAsync(Achizitie item, bool isNewItem = true)
        {
            return restService.SaveAchizitieAsync(item, isNewItem);
        }
        public Task DeleteAchizitieAsync(Achizitie item)
        {
            return restService.DeleteAchizitieAsync(item.ID);
        }

        

    }

}
