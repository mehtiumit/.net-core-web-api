using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class AppRepository : IAppRepository
    {
        private DataContext _context;
        public AppRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public List<Add> GetAdds()
        {


            var adds = _context.Adds.Include(p => p.Photos).ToList();
            return adds;
        }

        public Add GetAddsById(int addId)
        {
            var add = _context.Adds.Include(p => p.Photos).FirstOrDefault(a => a.AddId == addId);
            return (Add)add;
        }

        public List<Photo> GetPhotosByAdd(int addId)
        {

            var photos = _context.Photos.Where(p => p.Adds.AddId == addId).ToList();
            return photos;

        }

        public List<FavAds> GetFavAdds(int userId)
        {
            var favAdds = _context.FavAds.Where(fa => fa.UserId == userId).ToList();
            return favAdds;
        }

        public User GetUserById(int userId)
        {
            var user = _context.Users.Where(u => u.UserId == userId);
            return (User)user;
        }

        public List<User> GetUsers()
        {
            var users = _context.Users.ToList();
            return users;
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
