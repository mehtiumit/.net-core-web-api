using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Photo
    {
        
        public int PhotoId { get; set; }
        public string Url { get; set; }

        public Add Adds { get; set; }

    }
}
