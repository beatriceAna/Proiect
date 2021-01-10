using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Beatrice_Ana.Data;
using Proiect_Beatrice_Ana.Models;

namespace Proiect_Beatrice_Ana.Pages.Patients
{
    public class CreateModel : PatientAppointmentsPageModel
    {
        private readonly Proiect_Beatrice_Ana.Data.Proiect_Beatrice_AnaContext _context;

        public CreateModel(Proiect_Beatrice_Ana.Data.Proiect_Beatrice_AnaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DoctorID"] = new SelectList(_context.Set<Doctor>(), "ID", "Code");

            var patient = new Patient();
            patient.Appointments = new List<Appointment>();
            PopulateAssignedAvailabilityData(_context, patient);

            return Page();
        }

        [BindProperty]
        public Patient Patient { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedAppointments)
        {
            var newPatient = new Patient();
            if (selectedAppointments != null)
            {
                newPatient.Appointments = new List<Appointment>();
                foreach (var cat in selectedAppointments)
                {
                    var catToAdd = new Appointment
                    {
                        AvailableTimeDateID = int.Parse(cat)
                    };
                    newPatient.Appointments.Add(catToAdd);

                }
            }
            if (await TryUpdateModelAsync<Patient>(
                    newPatient,
                    "Patient",
                     i => i.FirstName, i => i.LastName, i => i.Address, i => i.CNP, i => i.PhoneNumber,
                       i => i.Insurance, i => i.DoctorID))
            {
                _context.Patient.Add(newPatient);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedAvailabilityData(_context, newPatient);
            return Page();

        }
    }
}
