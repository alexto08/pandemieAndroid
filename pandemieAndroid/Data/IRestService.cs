using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pandemieAndroid.Models;

namespace pandemieAndroid.Data
{
    public interface IRestService
    {
        Task<List<Achizitie>> RefreshDataAsync();
        Task SaveAchizitieAsync(Achizitie item, bool isNewItem);
        Task DeleteAchizitieAsync(int id);
        
    }
}

