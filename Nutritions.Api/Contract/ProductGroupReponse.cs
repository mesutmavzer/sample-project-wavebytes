using Nutritions.Api.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nutritions.Api.Contract;

namespace Nutritions.Api.Contract
{
    public class ProductgroupReponse
    {
        public Guid Id { get; set; }
        public string ProductGroupName { get; set; }

        public IEnumerable<ProductResponse> Products { get; set; }


        public static implicit operator ProductgroupReponse(Productgroep productGroup)
        {
            if (productGroup == null)
            {
                return null;
            }
            
            return new ProductgroupReponse()
            {
                Id = productGroup.Id,
                ProductGroupName = productGroup.ProductgroepNaam,
                Products = productGroup.Producten?.Select(product => (ProductResponse)product) ?? new List<ProductResponse>()

            };

        }
    }
}
