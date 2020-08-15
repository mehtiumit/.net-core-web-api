using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Dtos
{
    public class AddInfoDto
    {
        public int AddId { get; set; }
        public string AddInfo { get; set; }
        public List<Photo> Photos { get; set; }
    }
}
