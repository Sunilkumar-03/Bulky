using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repositories
{
    public class UnitWork :IUnitWork
    {
        private readonly ApplicationDbContext _context;
        public UnitWork(ApplicationDbContext context)
        {
            _context = context;
            category = new CategoryRepository(_context);
        }

        public ICategory category { get; private set; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
