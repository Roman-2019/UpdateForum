using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }

        public int CategoryModelId { get; set; }
        public CategoryModel CategoryModel { get; set; }

        public ICollection<CommentModel> CommentModels { get; set; }

        public int AuthorModelId { get; set; }
        public AuthorModel AuthorModel { get; set; }

        public ICollection<TagModel> TagModels { get; set; }
    }
}
