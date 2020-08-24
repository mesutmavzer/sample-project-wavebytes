using Nutritions.Api.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutritions.Api.Contract
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        
       


        public static implicit operator UserResponse(User user)
        {
            return new UserResponse()
            {
                Id = user.Id,
                Naam = user.Naam,
                Voornaam = user.Voornaam,
                Email= user.Email,
                PasswordHash=user.PasswordHash,
                PasswordSalt=user.PasswordSalt

            };
        }

    }
}
