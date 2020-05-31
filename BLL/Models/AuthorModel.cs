using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class AuthorModel
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public int CountComments { get; set; }
        public string Status { get; set; }

        public ICollection<CommentModel> CommentModels { get; set; }

        public ICollection<PostModel> PostModels { get; set; }

        public string IdentityId { get; set; }
    }
}
