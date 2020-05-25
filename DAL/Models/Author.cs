using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public int CountComments { get; set; }
        public string Status { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
