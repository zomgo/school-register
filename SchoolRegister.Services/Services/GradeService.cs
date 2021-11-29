using AutoMapper;
using SchoolRegister.BLL.Entities;
using SchoolRegister.DAL.EF;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.DTOs;
using SchoolRegister.ViewModels.VMs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolRegister.Services.Services
{
    public class GradeService : BaseService, IGradeService
    {
        public GradeService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public GradeVm AddGradeToStudent(AddGradeToStudentDto addGradeToStudentDto)
        {
            if (addGradeToStudentDto == null)
            {
                throw new ArgumentNullException($"Dto of type is null");
            }
            var gradeEntity = Mapper.Map<Grade>(addGradeToStudentDto);

            _dbContext.Grade.Add(gradeEntity);
            _dbContext.SaveChanges();
            var gradeVm = Mapper.Map<GradeVm>(gradeEntity);

            return gradeVm;
        }

        public GradesOfStudentVm GetAllGradesOfStudent(GetGradesDto getGradesDto)
        {
            throw new NotImplementedException();
        }
    }
}
