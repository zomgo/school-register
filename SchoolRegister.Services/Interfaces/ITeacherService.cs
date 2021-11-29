using SchoolRegister.BLL.Entities;
using SchoolRegister.ViewModels.DTOs;
using SchoolRegister.ViewModels.VMs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SchoolRegister.Services.Interfaces
{
    public interface ITeacherService
    {
        void SendEmailToParent(SendEmailToParentDto sendEmailToParentDto);
        TeacherVm GetTeacher(Expression<Func<Teacher, bool>> filterPredicate);
        IEnumerable<TeacherVm> GetTeachers(Expression<Func<Teacher, bool>> filterPredicate = null);

    }
}
