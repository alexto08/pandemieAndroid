using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pandemieAndroid2.Models;

namespace pandemieAndroid2.Data
{
    public class pandemieAndroid2Context : DbContext
    {
        public pandemieAndroid2Context (DbContextOptions<pandemieAndroid2Context> options)
            : base(options)
        {
        }

        public DbSet<pandemieAndroid2.Models.Achizitie> Achizitie { get; set; } = default!;

        public DbSet<pandemieAndroid2.Models.Fond>? Fond { get; set; }

        public DbSet<pandemieAndroid2.Models.Membru>? Membru { get; set; }

        public DbSet<pandemieAndroid2.Models.Producator>? Producator { get; set; }

        public DbSet<pandemieAndroid2.Models.Tara>? Tara { get; set; }

        public DbSet<pandemieAndroid2.Models.Tip>? Tip { get; set; }

        public DbSet<pandemieAndroid2.Models.Vaccin>? Vaccin { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<pandemieAndroid2.Models.StocNecesar>? StocNecesar { get; set; }
    }
}
