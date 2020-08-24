using Nutritions.Api.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using Nutritions.Api.DataModels;
using Microsoft.EntityFrameworkCore;
using Nutritions.Api.Contract;

namespace Nutritions.Api.Services
{
    public class UserService
    {
        public NutritionsContext NutritionsContext { get; set; }

        public UserService(NutritionsContext context)
        {
            this.NutritionsContext = context;
        }


        public User CreateUser(User user, string password)
        {
        
            EncryptPassword(password, out string salt1, out string hashed1);
            user.PasswordSalt = salt1;
            user.PasswordHash = hashed1;

            var addedUser = NutritionsContext.Users.Add(user);
            NutritionsContext.SaveChanges();
            return addedUser.Entity;
        }

        public void EncryptPassword(string password, out string salt, out string hashedPassword)
        {

            salt = Guid.NewGuid().ToString();
            hashedPassword = Convert.ToBase64String(new SHA1CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes($"{salt}{password}")));

        }

        public bool VerifyPassword(string password, string salt, string hashedPassword)
        {
            var hashedPasswordCheck = Convert.ToBase64String(new SHA1CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes($"{salt}{password}")));

            return hashedPasswordCheck == hashedPassword;
        }

        public User UpdateUser(Guid id, User user)
        {
            var toBeUpdatenUser = NutritionsContext.Users.SingleOrDefault(x => x.Id == id);
            toBeUpdatenUser.Naam = user.Naam;
            toBeUpdatenUser.Voornaam = user.Voornaam;

            NutritionsContext.SaveChanges();

            return toBeUpdatenUser;

            
        }

        public void DeleteUser(Guid id)
        {
            var toBeDeletenInvoice= NutritionsContext.Users.SingleOrDefault(x => x.Id == id);
            NutritionsContext.Users.Remove(toBeDeletenInvoice);
            NutritionsContext.SaveChanges();

            
        }


        public IEnumerable<User> GetAllUsers()
        {
            var allUsers = NutritionsContext.Users.Include(x => x.PersoonlijkDieet);
            return allUsers;
        }

        public User GetUserById(Guid id)
        {
            var oneUser = NutritionsContext.Users.FirstOrDefault(x => x.Id == id);

            return oneUser;
        }
    }
}
