using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_Beatrice_Ana.Models;

namespace Proiect_Beatrice_Ana.Data
{
    public class Proiect_Beatrice_AnaContext : DbContext
    {
        public Proiect_Beatrice_AnaContext (DbContextOptions<Proiect_Beatrice_AnaContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_Beatrice_Ana.Models.Patient> Patient { get; set; }

        public DbSet<Proiect_Beatrice_Ana.Models.Doctor> Doctor { get; set; }

        public DbSet<Proiect_Beatrice_Ana.Models.AvailableTimeDate> AvailableTimeDate { get; set; }
    }
}
