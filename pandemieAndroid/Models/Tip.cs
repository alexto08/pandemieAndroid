using System.ComponentModel.DataAnnotations;

namespace pandemieAndroid.Models
{
    public class Tip
    {
        public int ID { get; set; }
        [Display(Name = "Tip")]
        public string Nume_tip { get; set; }
        public ICollection<VaccinTip>? VaccinTip { get; set; }
    }
}
