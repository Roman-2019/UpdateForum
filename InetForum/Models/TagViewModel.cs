using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InetForum.Models
{
    public class TagViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Id Text is required")]
        public string Text { get; set; }
    }
}