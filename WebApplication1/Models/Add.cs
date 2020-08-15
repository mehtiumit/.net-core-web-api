using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class Add
    {

        public Add()
        {
            Photos = new List<Photo>();
            FavAdss = new List<FavAds>();
            AddAndCategories = new List<AddAndCategory>();
        }
       
        public int AddId { get; set; }
        public string AddInfo { get; set; }
        public User User { get; set; }

        public ICollection<Photo> Photos { get; set; }
        public Category Category { get; set; }

        public ICollection<FavAds> FavAdss { get; set; }
        public ICollection<AddAndCategory> AddAndCategories { get; set; }

    }
}
