using Nutritions.Api.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutritions.Api.Services
{
    public class PersoonlijkDieetService
    {
        public NutritionsContext NutritionsContext { get; set; }


        public PersoonlijkDieetService(NutritionsContext context)
        {
            this.NutritionsContext = context;

        }
    }
}
