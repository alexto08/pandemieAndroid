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
    public class pandemieDatabaseProducator
    {
        ProducatorIRestService restService;
        public pandemieDatabaseProducator(ProducatorIRestService service)
        {
            restService = service;
        }
        public Task<List<Producator>> GetProducatorAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task SaveProducatorAsync(Producator item, bool isNewItem = true)
        {
            return restService.SaveProducatorAsync(item, isNewItem);
        }
        public Task DeleteProducatorAsync(Producator item)
        {
            return restService.DeleteProducatorAsync(item.ID);
        }

        

    }

}
