using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirst.PatientManagement.Entities
{
    public class Patient
    {
        public Patient()
        {
            PatientAppointments = new List<Appointment>();
        }
        public int PatientId { get; set; }
        public string PatientName { get; set; }

        public virtual ICollection<Appointment> PatientAppointments { get; set; }
    }
}
