using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }

        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}
