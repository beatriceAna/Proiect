using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_Beatrice_Ana.Models
{
    public class Doctor
    {
        public int ID { get; set; }
        public string Code { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Prenumele medicului trebuie sa fie de forma 'Prenume' "), Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Numele medicului trebuie sa fie de forma 'Nume' "), Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public bool Available { get; set; }
        [Required]
        public string Type { get; set; }
        public ICollection<Patient> Patients { get; set; }
    }
}
