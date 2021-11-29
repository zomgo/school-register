using SchoolRegister.BLL.Entities;
using SchoolRegister.ViewModels.DTOs;
using SchoolRegister.ViewModels.VMs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SchoolRegister.Services.Interfaces
{
    public interface IGroupService
    {
        GroupVm AddOrUpdateGroup(AddOrUpdateGroupDto addOrUpdateGroupDto);
        StudentVm AddStudentToGroup(AddOrRemoveStudentToGroupDto addStudentToGroupDto);
        StudentVm RemoveStudentFromGroup(AddOrRemoveStudentToGroupDto removeStudentFromGroupDto);
        GroupVm GetGroup(Expression<Func<Group, bool>> filterPredicate);
        IEnumerable<GroupVm> GetGroups(Expression<Func<Group, bool>> filterPredicate = null);


    }
}
