using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_Beatrice_Ana.Models
{
    public class PatientData
    {
        public IEnumerable<Patient> Patients { get; set; }
        public IEnumerable<AvailableTimeDate> AvailableTimeDates { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }

    }
}
