﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_Beatrice_Ana.Models
{
    public class Patient
    {
        [Display(Name = "Patient ID")]
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Prenumele pacientlui trebuie sa fie de forma 'Prenume' "), Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Numele pacientului trebuie sa fie de forma 'Nume' "), Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "CNP-ul pacientului trebuie sa contina doar cifre "), Required, StringLength(13)]
        public string CNP { get; set; }
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Numarul de telefon al pacientului trebuie sa contina doar cifre "), Required,  StringLength(10)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        public bool Insurance { get; set; }

        public int DoctorID { get; set; }
        public Doctor Doctor { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
