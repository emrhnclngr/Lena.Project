using Lena.Project.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lena.Project.Entities.Entities
{
    public class Form : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        

        //Relational Property
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
