using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EfCodeFirst.PatientManagement.Data;
using EfCodeFirst.PatientManagement.Business;
using EfCodeFirst.PatientManagement.Entities;

namespace EfCodeFirst.PatientManagement.Data
{
    public class PatientManagementDatabase : DbContext
    {
        public PatientManagementDatabase() : base("PatientManagementContext")
        { 
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Patient> Patient { get; set; }
        public DbSet<Appointment> Appointment { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AppointmentMap());
            modelBuilder.Configurations.Add(new PatientMap()); 
        }
    }
}
