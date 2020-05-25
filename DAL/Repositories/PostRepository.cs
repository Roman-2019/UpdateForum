using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PostRepository : ForumRepository<Post>, IRepository<Post>
    {
        public PostRepository(DBContext dbctx) : base(dbctx)
        {
        }
    }
}
