using Nutritions.Api.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutritions.Api.Contract
{
    public class ProductGroupRequest
    {
        public string ProductGroupName { get; set; }

        public static explicit operator Productgroep(ProductGroupRequest productGroup)
        {
            return new Productgroep()
            {
                ProductgroepNaam = productGroup.ProductGroupName
            };
        }
    }
}
