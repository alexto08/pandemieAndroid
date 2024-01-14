using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pandemieAndroid.Models;

namespace pandemieAndroid.Data
{
    public interface TipIRestService
    {
            Task<List<Tip>> RefreshDataAsync();
            Task SaveTipAsync(Tip item, bool isNewItem);
            Task DeleteTipAsync(int id);
        
    }
}
