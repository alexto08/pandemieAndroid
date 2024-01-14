using System;
using pandemieAndroid.Data;
using System.IO;

namespace pandemieAndroid
{
    public partial class App : Application
{
    public static pandemieDatabaseAchizitie DatabaseAchizitie { get; private set; }
        public static pandemieDatabaseTip DatabaseTip { get; private set; }
        public static pandemieDatabaseProducator DatabaseProducator { get; private set; }
        public static pandemieDatabaseVaccin DatabaseVaccin { get; private set; }
        public static pandemieDatabaseTara DatabaseTara { get; private set; }
        public static pandemieDatabaseMembru DatabaseMembru { get; private set; }
        public static pandemieDatabaseFond DatabaseFond { get; private set; }
        public static pandemieDatabaseStocNecesar DatabaseStocNecesar { get; private set; }


        public App()
    {
        InitializeComponent();
        DatabaseAchizitie = new pandemieDatabaseAchizitie(new RestService());
            DatabaseTip = new pandemieDatabaseTip(new TipRestService());
            DatabaseMembru = new pandemieDatabaseMembru(new MembruRestService());
            DatabaseVaccin = new pandemieDatabaseVaccin(new VaccinRestService());
            DatabaseTara = new pandemieDatabaseTara(new TaraRestService());
            DatabaseFond = new pandemieDatabaseFond(new FondRestService());
            DatabaseProducator = new pandemieDatabaseProducator(new ProducatorRestService());
            DatabaseStocNecesar = new pandemieDatabaseStocNecesar(new StocNecesarRestService());
            MainPage = new AppShell();

    }
}
}