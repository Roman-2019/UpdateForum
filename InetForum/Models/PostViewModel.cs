using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InetForum.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Please input from 1 to 100 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Text is required")]
        [StringLength(10000, MinimumLength = 1, ErrorMessage = "Please input from 1 to 10000 characters")]
        public string Text { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }

        [Required(ErrorMessage = "Id Category is required")]
        public int CategoryViewModelId { get; set; }
        public CategoryViewModel CategoryViewModel { get; set; }

        [Required(ErrorMessage = "Id Author is required")]
        public int AuthorViewModelId { get; set; }
        public AuthorViewModel AuthorViewModel { get; set; }

        public ICollection<CommentViewModel> CommentViewModels { get; set; }

    }
}