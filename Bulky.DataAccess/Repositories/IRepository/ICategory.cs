using Bulky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repositories.IRepository
{
    public interface ICategory : IRepository<Categories>
    {
        void Update(Categories category);
    }
}
