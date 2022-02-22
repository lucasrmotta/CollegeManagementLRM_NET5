using Microsoft.AspNetCore.Mvc;

namespace CollegeManagementLRM_NET5.Controllers
{
    public class TeachersAreaController : Controller
    {
        public IActionResult StudentsInSubjects()
        {
            return View();
        }
        public IActionResult SubjectsGrades()
        {
            return View();
        }
    }
}
