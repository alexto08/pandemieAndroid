using pandemieAndroid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pandemieAndroid.Data
{
    public interface FondIRestService
    {
        Task<List<Fond>> RefreshDataAsync();
        Task SaveFondAsync(Fond item, bool isNewItem);
        Task DeleteFondAsync(int id);
    }
}
