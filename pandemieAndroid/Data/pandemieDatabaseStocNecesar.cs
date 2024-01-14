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
    public class pandemieDatabaseStocNecesar
    {
        StocNecesarIRestService restService;
        public pandemieDatabaseStocNecesar(StocNecesarIRestService service)
        {
            restService = service;
        }
        public Task<List<StocNecesar>> GetStocNecesarAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task SaveStocNecesarAsync(StocNecesar item, bool isNewItem = true)
        {
            return restService.SaveStocNecesarAsync(item, isNewItem);
        }
        public Task DeleteStocNecesarAsync(StocNecesar item)
        {
            return restService.DeleteStocNecesarAsync(item.ID);
        }

        

    }

}
