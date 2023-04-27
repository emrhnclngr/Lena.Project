using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lena.Project.Entities.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get => _createDate; set => _createDate = value; }

        private DateTime _createDate = DateTime.Now;

        public bool Status { get; set; }
    }
}
