using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InetForum.Models
{
    public class PostCategory
    {
        public IEnumerable<PostViewModel> Posts { get; set; }
        public SelectList Categories { get; set; }

    }
}