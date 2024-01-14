using pandemieAndroid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pandemieAndroid.Data
{
    public interface MembruIRestService
    {
        Task<List<Membru>> RefreshDataAsync();
        Task SaveMembruAsync(Membru item, bool isNewItem);
        Task DeleteMembruAsync(int id);
    }
}
