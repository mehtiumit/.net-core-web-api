using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string password { get; set; }
        public string passwordSalt { get; set; }

        public byte[] password1 { get; set; }
        public byte[] passwordSalt1 { get; set; }

        public ICollection<Add> Adds { get; set; }

        public ICollection<FavAds> FavAdss { get; set; }

    }
}
