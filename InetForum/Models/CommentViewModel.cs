using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InetForum.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Text is required")]
        [StringLength(5000, MinimumLength = 1, ErrorMessage = "Please input from 1 to 5000 characters")]
        public string Text { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }

        [Required(ErrorMessage = "Id Post is required")]
        public int PostViewModelId { get; set; }
        public PostViewModel PostViewModel { get; set; }

        [Required(ErrorMessage = "Id Author is required")]
        public int AuthorViewModelId { get; set; }
        public AuthorViewModel AuthorViewModel { get; set; }
    }
}