using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class PictureModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
    }
}
