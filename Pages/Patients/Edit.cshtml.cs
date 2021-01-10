using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Beatrice_Ana.Data;
using Proiect_Beatrice_Ana.Models;

namespace Proiect_Beatrice_Ana.Pages.Patients
{
    public class EditModel : PatientAppointmentsPageModel
    {
        private readonly Proiect_Beatrice_Ana.Data.Proiect_Beatrice_AnaContext _context;

        public EditModel(Proiect_Beatrice_Ana.Data.Proiect_Beatrice_AnaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Patient Patient { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient = await _context.Patient
                .Include(b=>b.Doctor)
                .Include(b=>b.Appointments).ThenInclude(b=>b.AvailableTimeDate)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Patient == null)
            {
                return NotFound();
            }

            PopulateAssignedAvailabilityData(_context, Patient);
            ViewData["DoctorID"] = new SelectList(_context.Set<Doctor>(), "ID", "Code");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedAppointments)
        {
            if (id == null)
            {
                return NotFound();
            }
            var patientToUpdate = await _context.Patient
                .Include(i => i.Doctor)
                .Include(i => i.Appointments)
                .ThenInclude(i => i.AvailableTimeDate)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (patientToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Patient>(
                patientToUpdate,
                "Patient",
                i => i.FirstName, i => i.LastName, i => i.Address, i => i.CNP, i => i.PhoneNumber,
                i => i.Insurance, i => i.Doctor))
            {
                UpdateAvailableHoursAndDates(_context, selectedAppointments, patientToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateAvailableHoursAndDates(_context, selectedAppointments, patientToUpdate);
            PopulateAssignedAvailabilityData(_context, patientToUpdate);
            return Page();

        }
    }
}
