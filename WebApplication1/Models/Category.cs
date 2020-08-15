using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Add> Adds { get; set; }

        public ICollection<AddAndCategory> AddAndCategories { get; set; }

    }
}
