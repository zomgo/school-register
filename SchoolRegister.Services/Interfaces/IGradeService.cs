using System;
using System.Collections.Generic;
using System.Text;
using SchoolRegister.BLL.Entities;
using SchoolRegister.ViewModels.DTOs;
using SchoolRegister.ViewModels.VMs;

namespace SchoolRegister.Services.Interfaces
{
    public interface IGradeService
    {
        GradeVm AddGradeToStudent(AddGradeToStudentDto addGradeToStudentDto);
        GradesOfStudentVm GetAllGradesOfStudent(GetGradesDto getGradesDto);
        
    }
}
