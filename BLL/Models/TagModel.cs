using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class TagModel
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public ICollection<PostModel> PostModels { get; set; }

        public ICollection<CommentModel> CommentModels { get; set; }
    }
}
