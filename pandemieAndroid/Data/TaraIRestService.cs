using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pandemieAndroid.Models;

namespace pandemieAndroid.Data
{
    public interface TaraIRestService
    {
        Task<List<Tara>> RefreshDataAsync();
        Task SaveTaraAsync(Tara item, bool isNewItem);
        Task DeleteTaraAsync(int id);
    }
}
