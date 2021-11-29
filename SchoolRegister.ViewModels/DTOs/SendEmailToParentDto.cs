using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolRegister.ViewModels.DTOs
{
    public class SendEmailToParentDto
    {
        [Required]
        public int TeacherId;
        [Required]
        public int StudentId;
        [Required]
        public string Title;
        [Required]
        public string Messege;
    }
}
