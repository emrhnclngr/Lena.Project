using Lena.Project.Common.Enums;
using Lena.Project.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lena.Project.Dtos
{
    public class AppUserLoginDto : IDto
    {
        
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
