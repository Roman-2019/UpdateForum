using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AuthorRepository : ForumRepository<Author>, IRepository<Author>
    {
        public AuthorRepository(DBContext dbctx) : base(dbctx)
        {
        }

    }
}
