using Microsoft.EntityFrameworkCore;
using Nutritions.Api.DataModels;
using Nutritions.Api.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutritions.Api.Services
{
    public class ProductService
    {
        public NutritionsContext NutritionsContext { get; set; }

        public ProductService(NutritionsContext context)
        {
            this.NutritionsContext = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var allProducts = NutritionsContext.Producten.Include(x => x.Productgroep);

            return allProducts;
        }

        public IEnumerable<Product> GetAllProductsInitial(string letter)
        {
            
            var allProducts = NutritionsContext.Producten.Include(x=>x.Productgroep).Where(x => x.ProductNaam.StartsWith(letter.ToLower()));
            return allProducts;
        }

        public Product GetProductById(Guid id)
        {
            var oneProduct = NutritionsContext.Producten.Include(x => x.Productgroep).FirstOrDefault(x => x.Id == id);
            return oneProduct;
        }

        public Product GetProductByName(string name)
        {
            var oneProduct = NutritionsContext.Producten.Include(x => x.Productgroep).FirstOrDefault(x => x.ProductNaam.ToLower() == name.ToLower());
            return oneProduct;
        }

        public void DeleteProduct(Guid id)
        {
            var toBeDeletenProduct = GetProductById(id);
            NutritionsContext.Producten.Remove(toBeDeletenProduct);
            NutritionsContext.SaveChanges();

        }

        public Product UpdateProduct(Guid id, Product product )
        {
            var toBeUpdatenProduct = NutritionsContext.Producten.Include(x => x.Productgroep).SingleOrDefault(x => x.Id == id);
            toBeUpdatenProduct.ProductNaam = product.ProductNaam;
            toBeUpdatenProduct.Productgroep = product.Productgroep;
            toBeUpdatenProduct.Beschrijving = product.Beschrijving;
            toBeUpdatenProduct.Gevoelswaarde = product.Gevoelswaarde;
            toBeUpdatenProduct.Gezondheidswaarde = product.Gezondheidswaarde;
            toBeUpdatenProduct.ProductPortie = product.ProductPortie;
            toBeUpdatenProduct.Productgroep = product.Productgroep;
            toBeUpdatenProduct.EnergieInKcal = product.EnergieInKcal;
            toBeUpdatenProduct.EnergieInKJoule = product.EnergieInKJoule;
            toBeUpdatenProduct.Water = product.Water;
            toBeUpdatenProduct.Eiwit = product.Eiwit;
            toBeUpdatenProduct.Vet = product.Vet;
            toBeUpdatenProduct.VerzadigdVet = product.VerzadigdVet;
            toBeUpdatenProduct.EnkelvoudigVerzadigdVet = product.EnkelvoudigVerzadigdVet;
            toBeUpdatenProduct.MeervoudigVerzadigdVet = product.MeervoudigVerzadigdVet;
            toBeUpdatenProduct.Koolhydraten = product.Koolhydraten;
            toBeUpdatenProduct.Suikers = product.Suikers;
            toBeUpdatenProduct.Voedingsvezels = product.Voedingsvezels;
            toBeUpdatenProduct.VitamineA = product.VitamineA;
            toBeUpdatenProduct.VitamineB1 = product.VitamineB1;
            toBeUpdatenProduct.VitamineB2 = product.VitamineB2;
            toBeUpdatenProduct.VitamineB6 = product.VitamineB6;
            toBeUpdatenProduct.VitamineB11 = product.VitamineB11;
            toBeUpdatenProduct.VitamineB12 = product.VitamineB12;
            toBeUpdatenProduct.VitamineC = product.VitamineC;
            toBeUpdatenProduct.VitamineD = product.VitamineD;
            toBeUpdatenProduct.Natrium = product.Natrium;
            toBeUpdatenProduct.Fosfor = product.Fosfor;
            toBeUpdatenProduct.Ijzer = product.Ijzer;
            toBeUpdatenProduct.Magnesium = product.Magnesium;
            toBeUpdatenProduct.Koper = product.Koper;
            toBeUpdatenProduct.Calcium = product.Calcium;
            toBeUpdatenProduct.Kalium = product.Kalium;
            toBeUpdatenProduct.Zink = product.Zink;

            NutritionsContext.SaveChanges();

            return (toBeUpdatenProduct);
        }

        public Product CreateProduct(Product product)
        {
            var newProduct = NutritionsContext.Producten.Add(product);
            NutritionsContext.SaveChanges();

            return product;
        }
    }
}
