using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Student_Data.Model;

namespace Student_Data.Pages
{
    public class EditPageModel : PageModel
    {

        public EditPageModel(StudentDbContext studentdbcontext)
        {
            _studentdbcontext = studentdbcontext;
        }

        private readonly StudentDbContext _studentdbcontext;

        [BindProperty]
        public Student StudentEntry { get; set; }

       
        public void OnGet(int id)
        {
            StudentEntry = _studentdbcontext.Students.FirstOrDefault(student => student.StudentCode == id);
        }

        public ActionResult OnPost() {
            if (!ModelState.IsValid) {
                return Page();
            }
            var stud = _studentdbcontext.Students.FirstOrDefault
                (student => student.StudentCode == StudentEntry.StudentCode);

            if (stud != null) {
                //update each field
                stud.FirstName = StudentEntry.FirstName;
                stud.LastName = StudentEntry.LastName;
                stud.Age = StudentEntry.Age;
                stud.Address = StudentEntry.Address;
                stud.Course = StudentEntry.Course;
                stud.Year = StudentEntry.Year;
                stud.Campus = StudentEntry.Campus;

                //update data
                _studentdbcontext.Update(stud);

                //save
                _studentdbcontext.SaveChanges();
            }
            return Redirect("StudentDataEntry");
        }
    }


}
