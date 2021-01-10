using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_Beatrice_Ana.Models
{
    public class Appointment
    {
        public int ID { get; set; }
        public int PatientID { get; set; }
        public Patient Patient { get; set; }
        public int AvailableTimeDateID { get; set; }
        public AvailableTimeDate AvailableTimeDate { get; set; }
    }
}
