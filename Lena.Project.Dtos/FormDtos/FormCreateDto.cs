using Lena.Project.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lena.Project.Dtos
{
    public class FormCreateDto : IDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int AppUserId { get; set; }
        
    }
}
