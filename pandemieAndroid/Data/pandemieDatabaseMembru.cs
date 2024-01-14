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
    public class pandemieDatabaseMembru
    {
        MembruIRestService restService;
        public pandemieDatabaseMembru(MembruIRestService service)
        {
            restService = service;
        }
        public Task<List<Membru>> GetMembruAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task SaveMembruAsync(Membru item, bool isNewItem = true)
        {
            return restService.SaveMembruAsync(item, isNewItem);
        }
        public Task DeleteMembruAsync(Membru item)
        {
            return restService.DeleteMembruAsync(item.ID);
        }

        

    }

}
