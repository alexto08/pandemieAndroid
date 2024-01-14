using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pandemieAndroid.Models;

namespace pandemieAndroid.Data
{
    public interface StocNecesarIRestService
    {
        Task<List<StocNecesar>> RefreshDataAsync();
        Task SaveStocNecesarAsync(StocNecesar item, bool isNewItem);
        Task DeleteStocNecesarAsync(int id);
    }
}
