using pandemieAndroid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pandemieAndroid.Data
{
    public interface ProducatorIRestService
    {
        Task<List<Producator>> RefreshDataAsync();
        Task SaveProducatorAsync(Producator item, bool isNewItem);
        Task DeleteProducatorAsync(int id);
    }
}
