using SchoolRegister.BLL.Entities;
using SchoolRegister.ViewModels.VMs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SchoolRegister.Services.Interfaces
{
    public interface IStudentService
    {
        IEnumerable<StudentVm> GetStudents(Expression<Func<Student, bool>> filterPredicate = null);
        StudentVm GetStudent(Expression<Func<Student, bool>> filterPredicate);
    }
}
