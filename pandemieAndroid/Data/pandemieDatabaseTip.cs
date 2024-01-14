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
    public class pandemieDatabaseTip
    {
        TipIRestService tipRestService;
        public pandemieDatabaseTip(TipIRestService service)
        {
            tipRestService = service;
        }
        public Task<List<Tip>> GetTipAsync()
        {
            return tipRestService.RefreshDataAsync();
        }

        public Task SaveTipAsync(Tip item, bool isNewItem = true)
        {
            return tipRestService.SaveTipAsync(item, isNewItem);
        }
        public Task DeleteTipAsync(Tip item)
        {
            return tipRestService.DeleteTipAsync(item.ID);
        }
    }

}
