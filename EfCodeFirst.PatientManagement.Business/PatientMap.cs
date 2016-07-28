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
    public class PatientMap : EntityTypeConfiguration<Patient>
    {
        public PatientMap()
        {
            // Key 
            HasKey(k => k.PatientId);

            // Properties
            Property(p => p.PatientId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.PatientName).IsRequired().HasMaxLength(50);

            // To Table
            ToTable("Patients");
        }
    }
}