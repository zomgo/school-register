using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolRegister.BLL.Entities;
using SchoolRegister.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolRegister.ViewModels.DTOs;
using Microsoft.AspNetCore.Authorization;
using System.Linq.Expressions;

namespace SchoolRegister.Web.Controllers
{
    public class StudentController : Controller
    {

        private readonly IStudentService _studentService;
        private readonly ISubjectService _subjectService;
        private readonly ITeacherService _teacherService;
        private readonly UserManager<User> _userManager;
        private readonly IGradeService _gradeService;
        private readonly IGroupService _groupService;
        

        public StudentController(ISubjectService subjectService, ITeacherService teacherService, UserManager<User> userManager, IGradeService gradeService, IGroupService groupService, IStudentService studentService)
        {
            _studentService = studentService;
            _subjectService = subjectService;
            _teacherService = teacherService;
            _userManager = userManager;
            _gradeService = gradeService;
            _groupService = groupService;
            
        }
        [Authorize(Roles ="Teacher,Admin,Parent,Student")]
        public IActionResult Index(string filterValue = null)
        {
            Expression<Func<Student, bool>> filterPredicate = null;
            if (!string.IsNullOrWhiteSpace(filterValue))
            {
                filterPredicate = x => (x.FirstName.Contains(filterValue)|| x.LastName.Contains(filterValue));
            }
            bool isAjax = HttpContext.Request.Headers["x-requested-with"] == "XMLHttpRequest";

            var user = _userManager.GetUserAsync(User).Result;
            if ((_userManager.IsInRoleAsync(user, "Admin").Result) || (_userManager.IsInRoleAsync(user, "Teacher").Result))
            {
                var studentsVm = _studentService.GetStudents(filterPredicate);
                if (isAjax)
                {
                    return PartialView("_StudentsTableDataPartial", studentsVm);
                }
                return View(studentsVm);
            }
            else if (_userManager.IsInRoleAsync(user, "Parent").Result)
            {
                var parent = _userManager.GetUserAsync(User).Result as Parent;
                return View(_studentService.GetStudents(s => s.ParentId == parent.Id));
            }
            else if (_userManager.IsInRoleAsync(user, "Student").Result)
            {
                var student = _userManager.GetUserAsync(User).Result as Student;
                return View(_studentService.GetStudents(s => s.Id == student.Id));
            }
            else
                return View("Error");
                
        }

   
        }
    }
