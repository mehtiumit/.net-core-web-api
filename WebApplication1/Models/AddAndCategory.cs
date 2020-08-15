using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class AddAndCategory
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int AddId { get; set; }
        public Add Add { get; set; }
    }
}
