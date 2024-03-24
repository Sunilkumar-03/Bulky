using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repositories.IRepository;
using Bulky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repositories
{
    public class CategoryRepository : Repository<Categories>, ICategory
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) :base(context)
        {
            _context = context;
        }

        public void Update(Categories category)
        {
            _context.Categories.Update(category);
        }
    }
}
