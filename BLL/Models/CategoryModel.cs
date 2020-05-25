using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Discription { get; set; }

        public ICollection<PostModel> PostModels { get; set; }
    }
}
