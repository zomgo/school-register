using AutoMapper;
using SchoolRegister.BLL.Entities;
using SchoolRegister.DAL.EF;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SchoolRegister.Services.Services
{
    public class StudentService : BaseService, IStudentService
    {
        public StudentService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public StudentVm GetStudent(Expression<Func<Student, bool>> filterPredicate)
        {
            if (filterPredicate == null)
                throw new ArgumentNullException($"Predicate is null");

            Student studentEntity = _dbContext.Users.OfType<Student>()
                .FirstOrDefault();

            var studentVm = Mapper.Map<StudentVm>(studentEntity);
            return studentVm;
        }

        public IEnumerable<StudentVm> GetStudents(Expression<Func<Student, bool>> filterPredicate = null)
        {
            var studentEntities = _dbContext.Users.OfType<Student>()
                                   .AsQueryable();
            if (filterPredicate != null)
            {
                studentEntities = studentEntities.Where(filterPredicate);
            }
            var studentVms = Mapper.Map<IEnumerable<StudentVm>>(studentEntities);
            return studentVms;
        }
    }
}
