using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InetForum.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }

        public int CategoryViewModelId { get; set; }
        public CategoryViewModel CategoryViewModel { get; set; }

        public int AuthorViewModelId { get; set; }
        public AuthorViewModel AuthorViewModel { get; set; }

        public ICollection<CommentViewModel> CommentViewModels { get; set; }

    }
}