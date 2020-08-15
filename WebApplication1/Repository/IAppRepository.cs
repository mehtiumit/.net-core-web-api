using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IAppRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveAll();


        /*User*/
        List<User> GetUsers();
        User GetUserById(int userId);
        /*/User*/
        /*Adds*/
        List<Add> GetAdds();
        Add GetAddsById(int addId);
        List<Photo> GetPhotosByAdd(int addId);
        List<FavAds> GetFavAdds(int userId);
        /*/Adds*/
    }
}
