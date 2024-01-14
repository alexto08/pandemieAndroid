using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace pandemieAndroid.Models.ViewModels
{
    public class AchizitiiViewModel 
    {
        public ObservableCollection<Achizitie> Achizitii { get; set; } = new ObservableCollection<Achizitie>();

        // Funcție pentru adăugarea unei noi achiziții

        public AchizitiiViewModel()
        {
            // Incarcarea initiala a datelor din baza de date in colectie
            List<Achizitie> achizitiiFromDatabase = App.DatabaseAchizitie.GetAchizitieAsync().Result;
            Achizitii = new ObservableCollection<Achizitie>(achizitiiFromDatabase);
        }
        public void AdaugaAchizitie(Achizitie achizitie)
        {
            // Adăugarea în colecție
            Achizitii.Add(achizitie);

            // Adăugarea în baza de date
            App.DatabaseAchizitie.SaveAchizitieAsync(achizitie);
        }

        // Funcție pentru editarea unei achiziții existente
        public void EditareAchizitie(Achizitie achizitie)
        {
            // Actualizarea în colecție
            var existingAchizitie = Achizitii.FirstOrDefault(a => a.ID == achizitie.ID);
            if (existingAchizitie != null)
            {
                existingAchizitie.MembruID = achizitie.MembruID;
                existingAchizitie.VaccinID = achizitie.VaccinID;
                existingAchizitie.Data_achizitie = achizitie.Data_achizitie;
                existingAchizitie.Cantitate = achizitie.Cantitate;
            }

            // Actualizarea în baza de date
            App.DatabaseAchizitie.SaveAchizitieAsync(achizitie);
        }

        // Funcție pentru ștergerea unei achiziții
        public void StergeAchizitie(Achizitie achizitie)
        {
            // Ștergerea din colecție
            Achizitii.Remove(achizitie);

            // Ștergerea din baza de date
            App.DatabaseAchizitie.DeleteAchizitieAsync(achizitie);
        }
    }
}
