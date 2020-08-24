using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nutritions.Api.Contract;
using Nutritions.Api.DataModels;
using Nutritions.Api.DB;
using Nutritions.Api.Services;

namespace Nutritions.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductGroupsController : ControllerBase
    {
        public ProductgroupService ProductgroupService{ get; set; }
        public NutritionsContext NutritionsContext { get; set; }

        public ProductGroupsController(NutritionsContext context, ProductgroupService service)
        {
            this.NutritionsContext = context;
            this.ProductgroupService = service;
        }

        [HttpGet("{id}")]
        public IActionResult GetProductGroupById(Guid id)
        {
            var oneProductgroup = ProductgroupService.GetProductgroupById(id);
            return Ok((ProductgroupReponse)oneProductgroup);
        }

        [HttpGet]
        public IActionResult GetAllProductGroups()
        {
            var allProductGroups = ProductgroupService.GetAllProductGroups().ToList().Select(x => (ProductgroupReponse)x);

            return Ok(allProductGroups);

        }
        [HttpGet("Products/{id}")]
        public IActionResult GetAllProductsByProductGroupId(Guid id)
        {
            var allProductsByProductGroupId = ProductgroupService.GetAllProductsByProductGroupId(id).ToList().Select(x=>(ProductResponse)x);

            return Ok(allProductsByProductGroupId);
        }



        

        [HttpPost]
        public IActionResult CreateProductGroup([FromBody]ProductGroupRequest productGroup)
        {
            var newProductGroup=ProductgroupService.CreateProductGroup((Productgroep)productGroup);

            return Ok((ProductgroupReponse)newProductGroup);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProductGroup(Guid id, [FromBody]ProductGroupRequest productgroup)
        {
            var toBeUpdatenProductGroup=ProductgroupService.UpdateProductGroep(id, (Productgroep)productgroup);

            return Ok((ProductgroupReponse)toBeUpdatenProductGroup);
          
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProductGroupById(Guid id)
        {
            ProductgroupService.DeleteProductGroupById(id);
            return Ok();
        }



    }
}
