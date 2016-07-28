using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using EfCodeFirst.PatientManagement.Entities;

namespace EfCodeFirst.PatientManagement.Business
{
  

    public class AppointmentMap : EntityTypeConfiguration<Appointment>
    {
        public AppointmentMap()
        {
            // Key

            HasKey(k => k.AppointmentId);

            // Properties
            Property(p => p.AppointmentId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.AppointmentDateTime).IsRequired(); 

            // To Table
            ToTable("Appointments");
        }
    }
}
