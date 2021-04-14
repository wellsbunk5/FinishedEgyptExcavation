using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EgyptExcavation.Models;


namespace EgyptExcavation.Models
{
    public class ExcavationDbContext : IdentityDbContext<User, Role, int>
    {
        public ExcavationDbContext(DbContextOptions<ExcavationDbContext> options) : base(options)
        { }

        public ExcavationDbContext() //RDS database connection
        {
        }

        public static ExcavationDbContext Create()
        {
            return new ExcavationDbContext();
        }


        public DbSet<Burial> Burials { get; set; }
        public DbSet<CarbonDating> CarbonDatings { get; set; }
        public DbSet<Age_Groups> AgeGroups { get; set; }
        public DbSet<Skulls> Skulls { get; set; }
        public DbSet<HairColors> HairColors { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<Preservations> Preservations { get; set; }
        public DbSet<Labs> Labs { get; set; }
        public DbSet<Categories> Categories { get; set; }

	}
}
