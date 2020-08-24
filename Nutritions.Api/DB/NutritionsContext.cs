using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Nutritions.Api.DataModels;

namespace Nutritions.Api.DB
{
    public class NutritionsContext: DbContext
    {
        public NutritionsContext(DbContextOptions<NutritionsContext>options):base(options)
        {

        }

        public DbSet<Maaltijd> Maaltijden { get; set; }
        public DbSet<MaaltijdProduct> MaaltijdProducten { get; set; }
        public DbSet<PersoonlijkDieet> PersoonlijkDieeten { get; set; }
        public DbSet<Product> Producten { get; set; }
        public DbSet<Productgroep> Productgroepen { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
        }

    }
}
