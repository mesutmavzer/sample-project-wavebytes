using Nutritions.Api.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutritions.Api.Contract
{
    public class UserRequest
    {
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public static explicit operator User(UserRequest user)
        {
            return new User()
            {
                Naam = user.Naam,
                Voornaam = user.Voornaam,
                Email = user.Email,
            };
        }
    }
}



