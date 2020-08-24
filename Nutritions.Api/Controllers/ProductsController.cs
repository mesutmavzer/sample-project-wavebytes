using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nutritions.Api.DataModels;
using Nutritions.Api.DB;
using Newtonsoft.Json;
using System.IO;
using Nutritions.Api.Services;
using Nutritions.Api.Contract;

namespace Nutritions.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductService ProductService { get; set; }

        public NutritionsContext NutritionsContext { get; set; }

        public ProductsController(NutritionsContext context, ProductService productService)
        {
            this.NutritionsContext = context;
            this.ProductService = productService;
        }

        //[HttpGet()]
        //public IActionResult Test()
        //{
        //    List<EntryModel> entries = new List<EntryModel>();
        //    for (var i = 2; i < 1370; i++)
        //    {
        //        if (!System.IO.File.Exists($"C:\\scrapeWithDescription1\\{i}.json")) continue;
        //        var content = System.IO.File.ReadAllText($"C:\\scrapeWithDescription1\\{i}.json");
        //        var pContent = JsonConvert.DeserializeObject<EntryModel>(content);
        //        entries.Add(pContent);
        //    }
        //    var groepen = NutritionsContext.Productgroepen.ToList();


        //    entries.ForEach(x =>
        //    {
        //        var product = new Product()
        //        {
        //            ProductNaam = x.ProductNaam,
        //            Gevoelswaarde = x.Gevoelswaarde,
        //            EnergieInKcal = x.Kcal,
        //            Gezondheidswaarde = x.Gezondheidswaarde,
        //            EnergieInKJoule = x.KJoule,
        //            Water = x.Water,
        //            Eiwit = x.Proteine,
        //            Vet = x.Vet,
        //            VerzadigdVet = x.VerzadigdVet,
        //            EnkelvoudigVerzadigdVet = x.EnkelvoudigVerzadigdVet,
        //            MeervoudigVerzadigdVet = x.MeervoudigVerzadigdVet,
        //            Cholestrol = x.Cholestrol,
        //            Koolhydraten = x.Koolhydraten,
        //            Suikers = x.Suikers,
        //            Voedingsvezels = x.Voedingsvezels,
        //            VitamineA = x.VitamineA,
        //            VitamineB1 = x.VitamineB1,
        //            VitamineB11 = x.VitamineB11,
        //            VitamineB12 = x.VitamineB12,
        //            VitamineB2 = x.VitamineB2,
        //            VitamineB6 = x.VitamineB6,
        //            VitamineC = x.VitamineC,
        //            VitamineD = x.VitamineD,
        //            Natrium = x.Natrium,
        //            Kalium = x.Kalium,
        //            Calcium = x.Calcium,
        //            Fosfor = x.FosFor,
        //            Ijzer = x.Ijzer,
        //            Magnesium = x.Magnesium,
        //            Koper = x.Koper,
        //            Zink = x.Zink,
        //            Beschrijving = x.Beschrijving,
        //            ProductPortie = x.ProductGewichtPortie,
        //            ProductgroepId = groepen.Where(y => y.ProductgroepNaam == x.ProductGroep).First().Id
        //        };

        //        NutritionsContext.Producten.Add(product);

        //    });

        //    NutritionsContext.SaveChanges();

        //    return Ok();
        //}

        //public class EntryModel
        //{
        //    public string ProductNaam { get; set; }
        //    public string ProductGroep { get; set; }
        //    public string Beschrijving { get; set; }
        //    public double Gevoelswaarde { get; set; }
        //    public double Gezondheidswaarde { get; set; }
        //    public double ProductGewichtPortie { get; set; }
        //    public double Kcal { get; set; }
        //    public double KJoule { get; set; }
        //    public double Water { get; set; }
        //    public double Proteine { get; set; }
        //    public double Vet { get; set; }
        //    public double VerzadigdVet { get; set; }
        //    public double EnkelvoudigVerzadigdVet { get; set; }
        //    public double MeervoudigVerzadigdVet { get; set; }
        //    public double Cholestrol { get; set; }
        //    public double Koolhydraten { get; set; }
        //    public double Suikers { get; set; }
        //    public double Voedingsvezels { get; set; }


        //    public double VitamineA { get; set; }
        //    public double VitamineB1 { get; set; }
        //    public double VitamineB2 { get; set; }
        //    public double VitamineB6 { get; set; }
        //    public double VitamineB11 { get; set; }
        //    public double VitamineB12 { get; set; }
        //    public double VitamineC { get; set; }
        //    public double VitamineD { get; set; }

        //    public double Natrium { get; set; }
        //    public double Kalium { get; set; }
        //    public double Calcium { get; set; }
        //    public double FosFor { get; set; }
        //    public double Ijzer { get; set; }
        //    public double Magnesium { get; set; }
        //    public double Koper { get; set; }
        //    public double Zink { get; set; }


        //    public EntryModel()
        //    {

        //    }
        //}








        //    var groepen = entries.Select(x => x.ProductGroep).Distinct().ToList();

        //    groepen.ForEach(x =>
        //    {
        //        var p = new Productgroep()
        //        {
        //            ProductgroepNaam = x
        //        };
        //        NutritionsContext.Productgroepen.Add(p);
        //    });

        //    NutritionsContext.SaveChanges();
        //    return Ok();
        //}

        [HttpGet("{id}")]
        public IActionResult GetProductById(Guid id)
        {
            var oneProduct = ProductService.GetProductById(id);

            return Ok((ProductResponse)oneProduct);
        }
        [HttpGet("initial/{letter}")]
        public IActionResult GetAllProductsInitial( string letter)
        {
            var allProducts = ProductService.GetAllProductsInitial(letter).Select(x=>(ProductResponse)x).OrderBy(x=>x.ProductNaam).ToList();
            return Ok (allProducts);
        }

        [HttpGet]
        public IActionResult GetAllProducts(int pageIndex=0, int pageSize=20, string query = "")
        {
            ApiPageResponse<ProductResponse> response;
            if (string.IsNullOrWhiteSpace(query))
                query = string.Empty;
           var allProducts= ProductService.GetAllProducts().Where(x=>x.ProductNaam.ToLower().Contains(query.ToLower())).Skip(pageIndex * pageSize).Take(pageSize).ToList().Select(product => (ProductResponse)product);
            response = new ApiPageResponse<ProductResponse>()
            {
                Items = allProducts,
                PageSize = pageSize,
                PageIndex = pageIndex,
                Total = ProductService.GetAllProducts().Count()
            };
           return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody]ProductRequest product)
        {
            var newProduct= ProductService.CreateProduct((Product)product);

            return Ok((ProductResponse)(newProduct));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProductById(Guid id, [FromBody] ProductRequest product)
        {
            var toBeUpdatenProduct = ProductService.UpdateProduct(id, (Product)product);

            return Ok((ProductResponse)toBeUpdatenProduct);




        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProductById(Guid id)
        {
            ProductService.DeleteProduct(id);
            return Ok();

        }
    }
}