using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }

        public int PostModelId { get; set; }
        public PostModel PostModel { get; set; }

        public int AuthorModelId { get; set; }
        public AuthorModel AuthorModel { get; set; }

        public ICollection<TagModel> TagModels { get; set; }
    }
}
