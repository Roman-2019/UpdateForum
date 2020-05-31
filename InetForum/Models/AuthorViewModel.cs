using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InetForum.Models
{
    public class AuthorViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "NickName is required")]
        public string NickName { get; set; }
        public int CountComments { get; set; }
        public string Status { get; set; }

        public string IdentityId { get; set; }
    }
}