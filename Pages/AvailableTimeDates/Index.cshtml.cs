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
    public class IndexModel : PageModel
    {
        private readonly Proiect_Beatrice_Ana.Data.Proiect_Beatrice_AnaContext _context;

        public IndexModel(Proiect_Beatrice_Ana.Data.Proiect_Beatrice_AnaContext context)
        {
            _context = context;
        }

        public IList<AvailableTimeDate> AvailableTimeDate { get;set; }

        public async Task OnGetAsync()
        {
            AvailableTimeDate = await _context.AvailableTimeDate.ToListAsync();
        }
    }
}
