using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Student_Data.Model;

namespace Student_Data.Pages
{
    public class StudentDataEntryModel : PageModel
    {

        public StudentDataEntryModel(StudentDbContext studentcontext)
        {
            _studentdbcontext = studentcontext;
        }

        private readonly StudentDbContext _studentdbcontext;

        [BindProperty]
        public Student StudentEntry { get; set; }

        public List<Student> Students = new List<Student>();

        public void OnGet()
        {
            Students = _studentdbcontext.Students.ToList();
        }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {

                Students = _studentdbcontext.Students.ToList();
                return Page();
            }

            _studentdbcontext.Students.Add(StudentEntry);
            _studentdbcontext.SaveChanges();
            return Redirect("/StudentDataEntry");
        }

        public void OnGetDelete(int id) {

            var stud = _studentdbcontext.Students.FirstOrDefault(std => std.StudentCode == id);

            if (stud != null) {
                _studentdbcontext.Students.Remove(stud);
                _studentdbcontext.SaveChanges();
            }

            OnGet();
        }
    }

}
