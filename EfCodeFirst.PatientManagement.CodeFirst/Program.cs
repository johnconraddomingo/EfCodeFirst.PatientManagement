using EfCodeFirst.PatientManagement.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfCodeFirst.PatientManagement.Entities;

namespace EfCodeFirst.PatientManagement.CodeFirst
{
    class Program
    {
        private static void CreateDatasource()
        { 
            Database.SetInitializer(new CreateDatabaseIfNotExists<PatientManagementDatabase>()); 

            var context = new PatientManagementDatabase();
            context.Patient.Create();
            context.Appointment.Create();

            context.SaveChanges();
        }

        static void Main(string[] args)
        {
             

            // Create

            CreateDatasource();

            // I'm just doing a demo, so i'll query here.

            Console.WriteLine("Inserting John's appointment for 1/1/2011 10:00:00 AM...");

            using (var context = new PatientManagementDatabase())
            {

                var insertThisPatient = new Patient
                {
                    PatientName = "John",
                    PatientAppointments = new List<Appointment>()
                    {
                        new Appointment
                        {
                            AppointmentDateTime = new DateTime(2011,1,1, 10,0,0)
                        }
                    }
                };
                context.Patient.Add(insertThisPatient);
                context.SaveChanges();
            }

            Console.WriteLine("Inserted. Now querying...");

            List<Patient> patientsList;
            using (var context = new PatientManagementDatabase())
            { 
                patientsList = context.Patient.Include(a => a.PatientAppointments).ToList(); 
            }

            foreach (var patientHere in patientsList)
            {
                Console.WriteLine($"{patientHere.PatientName} has an appointment at {patientHere.PatientAppointments.FirstOrDefault().AppointmentDateTime}");
            }

            Console.ReadLine();

        }
    }
}
