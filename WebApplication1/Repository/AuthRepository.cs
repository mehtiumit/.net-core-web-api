using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private DataContext _context;

        public AuthRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> Register(User user, string password)
        {

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.password1 = passwordHash;
            user.passwordSalt1 = passwordSalt;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;

        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hcmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hcmac.Key;
                passwordHash = hcmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<User> Login(string userName, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);

            if (user == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(password, user.password1, user.passwordSalt1))
            {
                return null;
            }

            return user;

        }

        private bool VerifyPasswordHash(string password, byte[] userPassword1, byte[] userPasswordSalt1)
        {
            using (var hcmac = new System.Security.Cryptography.HMACSHA512(userPasswordSalt1))
            {
                var computedHash = hcmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != userPassword1[i])
                    {
                        return false;
                    }

                }
                return true;
            }
        }

        public async Task<bool> UserExists(string userName)
        {
            if (await _context.Users.AnyAsync(u => u.UserName == userName))
            {
                return true;
            }

            return false;
        }
    }
}
