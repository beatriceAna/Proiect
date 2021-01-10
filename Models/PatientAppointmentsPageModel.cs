using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_Beatrice_Ana.Data;

namespace Proiect_Beatrice_Ana.Models
{
    public class PatientAppointmentsPageModel : PageModel
    {
        public List<AssignedAvailabilityData> AssignedAvailabilityDataList;
        public void PopulateAssignedAvailabilityData(Proiect_Beatrice_AnaContext context, Patient patient)
        {
            var allDates = context.AvailableTimeDate;
            var appointments = new HashSet<int>(patient.Appointments.Select(c => c.PatientID));
            AssignedAvailabilityDataList = new List<AssignedAvailabilityData>();    
            foreach(var cat in allDates)
            {
                AssignedAvailabilityDataList.Add(new AssignedAvailabilityData
                {
                    AvailableTimeDateID = cat.ID,
                    DateTime = cat.Availabilty,
                    Assigned = appointments.Contains(cat.ID)
                });

            }
        }
        public void UpdateAvailableHoursAndDates(Proiect_Beatrice_AnaContext context, string[] selectedDatesAndHours, Patient patientToUpdate)
        {
            if(selectedDatesAndHours == null)
            {
                patientToUpdate.Appointments = new List<Appointment>();
                return;
            }
            var selectedAvailableDatesAndHoursHS = new HashSet<string>(selectedDatesAndHours);
            var appointments = new HashSet<int>(patientToUpdate.Appointments.Select(c => c.AvailableTimeDate.ID));

            foreach (var cat in context.AvailableTimeDate)
            {
                if (selectedAvailableDatesAndHoursHS.Contains(cat.ID.ToString()))
                {
                    if (!appointments.Contains(cat.ID))
                    {
                        patientToUpdate.Appointments.Add(new Appointment
                        {
                            PatientID = patientToUpdate.ID,
                            AvailableTimeDateID = cat.ID
                        }) ;

                    }
                }
                else
                {
                    if (appointments.Contains(cat.ID))
                    {
                        Appointment remove = patientToUpdate
                            .Appointments
                            .SingleOrDefault(i => i.AvailableTimeDateID == cat.ID);
                        context.Remove(remove);
                    }
                }
            }
        }
    }
}
