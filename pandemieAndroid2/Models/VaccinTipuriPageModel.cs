using Microsoft.AspNetCore.Mvc.RazorPages;
using pandemieAndroid2.Data;
namespace pandemieAndroid2.Models
{
    public class VaccinTipuriPageModel : PageModel
    {
        public List<AssignedTipData> AssignedTipDataList;
        public void PopulateAssignedTipData(pandemieAndroid2Context context,
        Vaccin vaccin)
        {
            var allTipuri = context.Tip;
            var vaccinTipuri = new HashSet<int>(
            vaccin.VaccinTipuri.Select(c => c.TipID));
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
        public void UpdateVaccinTipuri(pandemieAndroid2Context context,
        string[] selectedTipuri, Vaccin vaccinToUpdate)
        {
            if (selectedTipuri == null)
            {
                vaccinToUpdate.VaccinTipuri = new List<VaccinTip>();
                return;
            }
            var selectedTipuriHS = new HashSet<string>(selectedTipuri);
            var vaccinTipuri = new HashSet<int>
            (vaccinToUpdate.VaccinTipuri.Select(c => c.Tip.ID));
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
                        VaccinTip courseToRemove
                        = vaccinToUpdate
                        .VaccinTipuri
                        .SingleOrDefault(i => i.TipID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    
    }
}
