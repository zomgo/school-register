using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolRegister.BLL.Entities;
using SchoolRegister.DAL.EF;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.DTOs;
using SchoolRegister.ViewModels.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SchoolRegister.Services.Services
{
    public class GroupService : BaseService, IGroupService
    {
        public GroupService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public GroupVm AddOrUpdateGroup(AddOrUpdateGroupDto addOrUpdateGroupDto)
        {
            if (addOrUpdateGroupDto == null)
            {
                throw new ArgumentNullException($"Dto of type is null");
            }

            var groupEntity = Mapper.Map<Group>(addOrUpdateGroupDto);
            if (addOrUpdateGroupDto.Id == null || addOrUpdateGroupDto.Id == 0)
            {
                _dbContext.Groups.Add(groupEntity);
            }
            else
            {
                _dbContext.Groups.Update(groupEntity);
            }
            _dbContext.SaveChanges();
            var GroupVm = Mapper.Map<GroupVm>(groupEntity);
            return GroupVm;
        }
  

   

        public GroupVm GetGroup(Expression<Func<Group, bool>> filterPredicate)
        {
            if (filterPredicate == null)
                throw new ArgumentNullException($"Predicate is null");
            Group groupEntity = _dbContext.Groups
              //  .Include(g => g.Students)
              //  .Include(g => g.SubjectGroups)
                .FirstOrDefault(filterPredicate);
            GroupVm groupVm = Mapper.Map<GroupVm>(groupEntity);
            return groupVm;
        }

        public IEnumerable<GroupVm> GetGroups(Expression<Func<Group, bool>> filterPredicate = null)
        {
            var groupEntities = _dbContext.Groups
                .AsQueryable();
            if (filterPredicate != null)
            {
                groupEntities = groupEntities.Where(filterPredicate);
            }
            IEnumerable<GroupVm> groupVms = Mapper.Map<IEnumerable<GroupVm>>(groupEntities);
            return groupVms;
        }

        public StudentVm AddStudentToGroup(AddOrRemoveStudentToGroupDto addStudentToGroupDto)
        {

            if (addStudentToGroupDto == null)
            {
                throw new ArgumentNullException($"Dto of type is null");
            }
            var student = _dbContext.Users.OfType<Student>().FirstOrDefault(s => s.Id == addStudentToGroupDto.StudentId);
            var group = _dbContext.Groups.FirstOrDefault(g => g.Id == addStudentToGroupDto.GroupId);
            student.GroupId = group.Id;
            student.Group = group;
            _dbContext.SaveChanges();
            StudentVm studentVm = Mapper.Map<StudentVm>(student);
            return studentVm;
        }

        public StudentVm RemoveStudentFromGroup(AddOrRemoveStudentToGroupDto removeStudentFromGroupDto)
        {
            if (removeStudentFromGroupDto == null)
            {
                throw new ArgumentNullException($"Dto of type is null");
            }
            var student = _dbContext.Users.OfType<Student>().FirstOrDefault(s => s.Id == removeStudentFromGroupDto.StudentId);
            var group = _dbContext.Groups.FirstOrDefault(g => g.Id == removeStudentFromGroupDto.GroupId);
            student.GroupId = null;
            student.Group = null;
            _dbContext.SaveChanges();
            StudentVm studentVm = Mapper.Map<StudentVm>(student);
            return studentVm;
        }
    }
}
