﻿using SchoolRegister.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolRegister.ViewModels.VMs
{
    public class StudentVm
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ParentName { get; set; }
        public int ParentId { get; set; }
        public string GroupName { get; set; }
        public double AverageGrade { get; set; }
        public string UserName { get; set; }
        public IDictionary<string, double> AverageGradePerSubject { get; set; }
        public IDictionary<string, List<GradeScale>> GradesPerSubject { get; set; }
    }
}
