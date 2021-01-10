using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Beatrice_Ana.Data;
using Proiect_Beatrice_Ana.Models;

namespace Proiect_Beatrice_Ana.Pages.Patients
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Beatrice_Ana.Data.Proiect_Beatrice_AnaContext _context;

        public IndexModel(Proiect_Beatrice_Ana.Data.Proiect_Beatrice_AnaContext context)
        {
            _context = context;
        }

        public IList<Patient> Patient { get; set; }
        public PatientData PatientD { get; set; }
        public int PatientID { get; set; }
        public int AvailableTimeDateID { get; set; }

        public async Task OnGetAsync(int? id, int? availableTimeDateID)
        {
            PatientD = new PatientData();
            PatientD.Patients = await _context.Patient
                .Include(b => b.Doctor)
                .Include(b => b.Appointments)
                .ThenInclude(b => b.AvailableTimeDate)
                .AsNoTracking()
                .OrderBy(b => b.FirstName)
                .ToListAsync();
            if (id != null)
            {
                PatientID = id.Value;
                Patient patient = PatientD.Patients
                    .Where(i => i.ID == id.Value).Single();
                PatientD.AvailableTimeDates = patient.Appointments.Select(s => s.AvailableTimeDate);
            }
        }
    }
}
