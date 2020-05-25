using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InetForum.Models
{
    public class AuthorViewModel
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public int CountComments { get; set; }
        public string Status { get; set; }
    }
}