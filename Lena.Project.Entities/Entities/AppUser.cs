using Lena.Project.Common.Enums;
using Lena.Project.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lena.Project.Entities.Entities
{
    public class AppUser : BaseEntity
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public GenderType Gender { get; set; }

        //Relational Property
        public List<Form> Forms { get; set; }
    }
}
