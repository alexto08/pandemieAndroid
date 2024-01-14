using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pandemieAndroid.Models;

namespace pandemieAndroid.Data
{
    public class pandemieAndroidContext : DbContext
    {
        public pandemieAndroidContext (DbContextOptions<pandemieAndroidContext> options)
            : base(options)
        {
        }

        public DbSet<pandemieAndroid.Models.Achizitie> Achizitie { get; set; } = default!;

        public DbSet<pandemieAndroid.Models.Fond>? Fond { get; set; }

        public DbSet<pandemieAndroid.Models.Membru>? Membru { get; set; }

        public DbSet<pandemieAndroid.Models.Producator>? Producator { get; set; }

        public DbSet<pandemieAndroid.Models.Tara>? Tara { get; set; }

        public DbSet<pandemieAndroid.Models.Tip>? Tip { get; set; }

        public DbSet<pandemieAndroid.Models.Vaccin>? Vaccin { get; set; }
        public DbSet<pandemieAndroid.Models.StocNecesar>? StocNecesar { get; set; }
    }
}
