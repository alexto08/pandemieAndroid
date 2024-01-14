namespace pandemieAndroid2.Models
{
    public class StocNecesar
    {
        public int ID { get; set; }

        public string UnitateMedicala { get; set; }
        public int VaccinID { get; set; }
        public Vaccin? Vaccin { get; set; }
        public int Cantitate { get; set; }
       
    }
}
