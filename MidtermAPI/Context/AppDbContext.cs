using System;
using Microsoft.EntityFrameworkCore;
using MidtermAPI.Entities;

namespace MidtermAPI.Context
{
	public class AppDbContext : DbContext
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=sql-server,1433;Initial Catalog=MidtermDb;User ID=SA;Password=Y389bhjas.;TrustServerCertificate=true;");
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<PersonnelNumber> PersonnelNumbers { get; set; }
    }
}

