using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Beatrice_Ana.Data;
using Proiect_Beatrice_Ana.Models;

namespace Proiect_Beatrice_Ana.Pages.AvailableTimeDates
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Beatrice_Ana.Data.Proiect_Beatrice_AnaContext _context;

        public DetailsModel(Proiect_Beatrice_Ana.Data.Proiect_Beatrice_AnaContext context)
        {
            _context = context;
        }

        public AvailableTimeDate AvailableTimeDate { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AvailableTimeDate = await _context.AvailableTimeDate.FirstOrDefaultAsync(m => m.ID == id);

            if (AvailableTimeDate == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
