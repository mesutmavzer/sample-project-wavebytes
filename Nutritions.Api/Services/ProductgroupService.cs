using Nutritions.Api.DataModels;
using Nutritions.Api.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutritions.Api.Services
{
    public class ProductgroupService
    {

        public NutritionsContext NutritionsContext { get; set; }

        public ProductgroupService(NutritionsContext context)
        {
            this.NutritionsContext = context;
        }

        public IEnumerable<Productgroep> GetAllProductGroups()
        {

            var allProductGroups = NutritionsContext.Productgroepen;
            return allProductGroups;
        }

        public Productgroep GetProductgroupById(Guid id)
        {
            var oneProductGroup = NutritionsContext.Productgroepen.FirstOrDefault(x => x.Id == id);

            return oneProductGroup;
        }

        public void DeleteProductGroupById(Guid id)
        {
            var toBeDeletenProductGroup = NutritionsContext.Productgroepen.SingleOrDefault(x => x.Id == id);
            NutritionsContext.Productgroepen.Remove(toBeDeletenProductGroup);
            NutritionsContext.SaveChanges();

        }

        public Productgroep CreateProductGroup(Productgroep productGroup)
        {
            var addedProductGroup = NutritionsContext.Productgroepen.Add(productGroup);
            NutritionsContext.SaveChanges();

            return productGroup;
        }

        public IEnumerable<Product> GetAllProductsByProductGroupId(Guid id)
        {
            var allProductsByProductGroup = NutritionsContext.Producten.Where(x => x.ProductgroepId == id).ToList();

            return allProductsByProductGroup;
        }

        public Productgroep UpdateProductGroep(Guid id, Productgroep productgroup)
        {
            var toBeUpdatenProductGroup = NutritionsContext.Productgroepen.SingleOrDefault(x => x.Id == id);
            toBeUpdatenProductGroup.ProductgroepNaam = productgroup.ProductgroepNaam;
            NutritionsContext.SaveChanges();
            return toBeUpdatenProductGroup;
        }
    }
}
