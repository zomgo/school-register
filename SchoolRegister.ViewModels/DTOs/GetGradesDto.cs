﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolRegister.ViewModels.DTOs
{
    public class GetGradesDto
    {
        [Required]
        public int StudentId { get; set; }
    }
}
