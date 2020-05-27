using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InetForum.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Please input from 1 to 100 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Discription is required")]
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "Please input from 1 to 1000 characters")]
        public string Discription { get; set; }
    }
}