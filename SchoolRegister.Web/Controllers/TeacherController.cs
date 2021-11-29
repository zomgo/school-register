using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolRegister.BLL.Entities;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.DTOs;

namespace SchoolRegister.Web.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeacherController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ISubjectService _subjectService;
        private readonly IGradeService _gradeService;
        private readonly ITeacherService _teacherService;
        private readonly UserManager<User> _userManager;

        public TeacherController(IStudentService studentService, ISubjectService subjectService, IGradeService gradeService, ITeacherService teacherService, UserManager<User> userManager)
        {
            _studentService = studentService;
            _subjectService = subjectService;
            _gradeService = gradeService;
            _teacherService = teacherService;
            _userManager = userManager;
        }

        
        public IActionResult AddGrade(int? studentId = null)
        {
            var teacher = _userManager.GetUserAsync(User).Result;
            var students = _studentService.GetStudents();
            var subjects = _subjectService.GetSubjects();

            ViewBag.StudentsSelectList = new SelectList(students.Select(s => new
            {
                Text = $"{s.FirstName} {s.LastName }",
                Value = s.Id,
                
            })
            , "Value", "Text");

            ViewBag.SubjectsSelectList = new SelectList(subjects.Select(ss => new
            {
                Text = $"{ss.Name}",
                Value = ss.Id
            })
           , "Value", "Text");

            ViewBag.GradesScaleList = new SelectList(Enum.GetValues(typeof(GradeScale)).Cast<GradeScale>().Select(x => new
            {
                Text = x.ToString(),
                Value = ((int)x).ToString()
            }), "Value", "Text");

            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddGrade(AddGradeToStudentDto addGradeToStudentDto)
        {
            if (ModelState.IsValid)
            {
          
                _gradeService.AddGradeToStudent(addGradeToStudentDto);
                return RedirectToAction("Index","Student");
            }
            return View();

        }

        public IActionResult SendEmailToParent(int studentId)
        {
            return View();
        }
    }
}
    
