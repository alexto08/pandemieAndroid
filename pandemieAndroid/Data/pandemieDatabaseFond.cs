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
    public class pandemieDatabaseFond
    {
        FondIRestService restService;
        public pandemieDatabaseFond(FondIRestService service)
        {
            restService = service;
        }
        public Task<List<Fond>> GetFondAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task SaveFondAsync(Fond item, bool isNewItem = true)
        {
            return restService.SaveFondAsync(item, isNewItem);
        }
        public Task DeleteFondAsync(Fond item)
        {
            return restService.DeleteFondAsync(item.ID);
        }

        

    }

}
