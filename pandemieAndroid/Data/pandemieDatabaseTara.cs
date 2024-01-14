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
    public class pandemieDatabaseTara
    {
        TaraIRestService restService;
        public pandemieDatabaseTara(TaraIRestService service)
        {
            restService = service;
        }
        public Task<List<Tara>> GetTaraAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task SaveTaraAsync(Tara item, bool isNewItem = true)
        {
            return restService.SaveTaraAsync(item, isNewItem);
        }
        public Task DeleteTaraAsync(Tara item)
        {
            return restService.DeleteTaraAsync(item.ID);
        }

        

    }

}
