using AutoMapper;
using SchoolRegister.BLL.Entities;
using SchoolRegister.DAL.EF;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.DTOs;
using SchoolRegister.ViewModels.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Text;

namespace SchoolRegister.Services.Services
{
    public class TeacherService : BaseService, ITeacherService
    {
        private readonly SmtpClient _smtpClient;

        public TeacherService(SmtpClient smtpClient, ApplicationDbContext dbContext) : base(dbContext)
        {
            _smtpClient = smtpClient;
        }

        public TeacherVm GetTeacher(Expression<Func<Teacher, bool>> filterPredicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TeacherVm> GetTeachers(Expression<Func<Teacher, bool>> filterPredicate = null)
        {
            var teacherEntities = _dbContext.Users.OfType<Teacher>()
                                   .AsQueryable();
            if (filterPredicate != null)
            {
                teacherEntities = teacherEntities.Where(filterPredicate);
            }
            var teacherVms = Mapper.Map<IEnumerable<TeacherVm>>(teacherEntities);
            return teacherVms;
        }

        public void SendEmailToParent(SendEmailToParentDto sendEmailToParentDto)
        {
            if (sendEmailToParentDto == null)
            {
                throw new ArgumentNullException($"Dto of type is null");
            }
            var teacher = _dbContext.Users.OfType<Teacher>().FirstOrDefault(t => t.Id == sendEmailToParentDto.TeacherId);
            var student = _dbContext.Users.OfType<Student>().FirstOrDefault(s => s.Id == sendEmailToParentDto.StudentId);
            _smtpClient.Send(teacher.Email, student.Parent.Email, sendEmailToParentDto.Title, sendEmailToParentDto.Messege);
        }

        }
    }
