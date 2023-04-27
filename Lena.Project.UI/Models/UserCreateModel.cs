using Lena.Project.Common.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Lena.Project.UI.Models
{
    public class UserCreateModel
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public GenderType Gender { get; set; }
    }
}
