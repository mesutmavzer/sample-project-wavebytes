using Nutritions.Api.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutritions.Api.Contract
{
    public class PersoonlijkDieetResponse
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid?  UserId { get; set; }
        

        public static implicit operator PersoonlijkDieetResponse(PersoonlijkDieet persoonlijkDieet)
        {
            return new PersoonlijkDieetResponse()
            {
                Id = persoonlijkDieet.Id,
                Description = persoonlijkDieet.Beschrijving,
                UserId = persoonlijkDieet.UserId
            };
        }

    }
}
