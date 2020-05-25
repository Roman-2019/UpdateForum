using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InetForum.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }

        public int PostViewModelId { get; set; }
        public PostViewModel PostViewModel { get; set; }

        public int AuthorViewModelId { get; set; }
        public AuthorViewModel AuthorViewModel { get; set; }
    }
}