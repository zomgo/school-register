using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using SchoolRegister.BLL.Entities;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.DTOs;

namespace SchoolRegister.Web.Controllers
{
    [Authorize(Roles = "Admin,Teacher")]
    public class GroupController : BaseController<GroupController>
    {
        private readonly IGroupService _groupService;
        private readonly ITeacherService _teacherService;
        private readonly UserManager<User> _userManager;
        private readonly ISubjectService _subjectService;

        public GroupController(IGroupService groupService, ITeacherService teacherService, UserManager<User> userManager, ISubjectService subjectService, IStringLocalizer<GroupController> localizer, ILoggerFactory loggerFactory) : base(localizer, loggerFactory)
        {
            _groupService = groupService;
            _teacherService = teacherService;
            _userManager = userManager;
            _subjectService = subjectService;
        }

        public IActionResult Index()
        {
            return View(_groupService.GetGroups());
        }

    [HttpGet]
    [Authorize(Roles ="Admin")]
    public IActionResult AddOrEditGroup(int? id = null)
    {
        var user = _userManager.GetUserAsync(User).Result;
        if (_userManager.IsInRoleAsync(user,"Admin").Result)
            {
                if (id.HasValue)
                {
                    var subjectVm = _subjectService.GetSubject(x => x.Id == id);
                    ViewBag.ActionType = _localizer["Edit"];
                    return View(Mapper.Map<AddOrUpdateGroupDto>(subjectVm));
                }
                ViewBag.ActionType = _localizer["Add"];
                return View();
            }
            else
            {
                return View("Error");
            }
       
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddOrEditGroup (AddOrUpdateGroupDto addOrUpdateGroupDto)
        {
            if (ModelState.IsValid)
            {
                _groupService.AddOrUpdateGroup(addOrUpdateGroupDto);
                return RedirectToAction("Index");
            }
            return View();
        }

}
}