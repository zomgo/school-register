using AutoMapper;
using SchoolRegister.BLL.Entities;
using SchoolRegister.ViewModels.DTOs;
using SchoolRegister.ViewModels.VMs;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SchoolRegister.Web.Configuration
{
    public static class AutoMapperConfig
    {
        public static IMapperConfigurationExpression Mapping(this IMapperConfigurationExpression configurationExpression)
        {
            Mapper.Initialize(mapper =>
            {
                mapper.CreateMap<AddOrUpdateSubjectDto, Subject>();
                mapper.CreateMap<Group, GroupVm>();
                mapper.CreateMap<Subject, SubjectVm>()
                    .ForMember(dest => dest.TeacherName, x => x.MapFrom(src => $"{src.Teacher.FirstName} {src.Teacher.LastName}"))
                    .ForMember(dest => dest.Groups, x => x.MapFrom(src => src.SubjectGroups.Select(y => y.Group)));
                mapper.CreateMap<SubjectVm, AddOrUpdateSubjectDto>();
                mapper.CreateMap<Teacher, TeacherVm>();
               // mapper.CreateMap<Grade, GradeVm>()
               //     .ForMember(dest => dest.SubjectName, x => x.MapFrom(src => src.Subject.Name));
                mapper.CreateMap<Student, StudentVm>()
                    .ForMember(dest => dest.ParentName, x => x.MapFrom(src => $"{src.Parent.FirstName} {src.Parent.LastName}"))
                    .ForMember(dest => dest.GroupName, x => x.MapFrom(src => src.Group.Name));
                mapper.CreateMap<Student, GradesOfStudentVm>()
                    .ForMember(dest => dest.StudentFirstName, x => x.MapFrom(src => src.FirstName))
                    .ForMember(dest => dest.StudentLastName, x => x.MapFrom(src => src.LastName))
                    .ForMember(dest => dest.ParentName, x => x.MapFrom(src => $"{src.Parent.FirstName} {src.Parent.LastName}"))
                    .ForMember(dest => dest.GroupName, x => x.MapFrom(src => src.Group.Name));
                    //.ForMember(dest=>dest.StudentGradesPerSubject, )
                mapper.CreateMap<AddOrUpdateGroupDto, Group>();
                mapper.CreateMap<AddGradeToStudentDto, Grade>()
                    .ForMember(dest => dest.DateOfIssue, y => y.MapFrom(src => DateTime.Now));
                mapper.CreateMap<AddOrRemoveStudentToGroupDto, StudentVm>();



            });





            return configurationExpression;
        }
    }
}
