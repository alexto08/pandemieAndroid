
using pandemieAndroid.Data;
namespace pandemieAndroid.Models
{
    public class VaccinTipuriViewModel
    {
        public List<AssignedTipData> AssignedTipDataList;

        public void PopulateAssignedTipData(pandemieAndroidContext context, Vaccin vaccin)
        {
            var allTipuri = context.Tip.ToList(); // Asigurați-vă că încărcați toate tipurile într-o listă
            var vaccinTipuri = new HashSet<int>(vaccin.VaccinTipuri.Select(c => c.TipID));
            AssignedTipDataList = new List<AssignedTipData>();

            foreach (var cat in allTipuri)
            {
                AssignedTipDataList.Add(new AssignedTipData
                {
                    TipID = cat.ID,
                    Nume = cat.Nume_tip,
                    Assigned = vaccinTipuri.Contains(cat.ID)
                });
            }
        }

        public void UpdateVaccinTipuri(pandemieAndroidContext context, string[] selectedTipuri, Vaccin vaccinToUpdate)
        {
            if (selectedTipuri == null)
            {
                vaccinToUpdate.VaccinTipuri = new List<VaccinTip>();
                return;
            }

            var selectedTipuriHS = new HashSet<string>(selectedTipuri);
            var vaccinTipuri = new HashSet<int>(vaccinToUpdate.VaccinTipuri.Select(c => c.Tip.ID));

            foreach (var cat in context.Tip)
            {
                if (selectedTipuriHS.Contains(cat.ID.ToString()))
                {
                    if (!vaccinTipuri.Contains(cat.ID))
                    {
                        vaccinToUpdate.VaccinTipuri.Add(
                            new VaccinTip
                            {
                                VaccinID = vaccinToUpdate.ID,
                                TipID = cat.ID
                            });
                    }
                }
                else
                {
                    if (vaccinTipuri.Contains(cat.ID))
                    {
                        VaccinTip courseToRemove = vaccinToUpdate.VaccinTipuri.SingleOrDefault(i => i.TipID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }

}
