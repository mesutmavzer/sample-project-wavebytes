using Nutritions.Api.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutritions.Api.Contract
{
    public class PersoonlijkDieetRequest
    {
        public string Description { get; set; }

        public static explicit operator PersoonlijkDieet(PersoonlijkDieetRequest persoonlijkDieet)
        {
            return new PersoonlijkDieet()
            {
                Beschrijving = persoonlijkDieet.Description
            };
        }
    }
}
