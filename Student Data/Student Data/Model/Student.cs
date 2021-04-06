using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Data.Model
{
    public class Student
    {
        [Key]
        public int StudentCode { get; set; }

        [Required(ErrorMessage = "First Name is Required")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "Please fill your Age")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        public String Address { get; set; }

        [Required(ErrorMessage = "Please write your course")]
        public String Course { get; set; }

        [Required(ErrorMessage = "Please fill the Year Level")]
        public int Year { get; set; }

        [Required(ErrorMessage = "What campus are you from? (Main, METC,Lapu-Lapu Mandaue,Banilad)")]
        public String Campus { get; set; }

    }
}
