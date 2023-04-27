using Lena.Project.DataAccess.Context;
using Lena.Project.DataAccess.Interfaces;
using Lena.Project.DataAccess.Repositories;
using Lena.Project.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lena.Project.DataAccess.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly ProjectContext _context;

        public Uow(ProjectContext context)
        {
            _context = context;
        }
        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_context);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
