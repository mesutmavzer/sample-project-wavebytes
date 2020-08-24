using Nutritions.Api.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutritions.Api.Contract
{
    public class ProductResponse
    {
        public Guid Id { get; set; }
        public string ProductNaam { get; set; }
        public double ProductPortie { get; set; }
        public string Beschrijving { get; set; }
        public double Gevoelswaarde { get; set; }
        public double Gezondheidswaarde { get; set; }
        public double EnergieInKcal { get; set; }
        public double EnergieInKJoule { get; set; }
        public double Water { get; set; }
        public double Eiwit { get; set; }
        public double Vet { get; set; }
        public double VerzadigdVet { get; set; }
        public double EnkelvoudigVerzadigdVet { get; set; }
        public double MeervoudigVerzadigdVet { get; set; }
        public double Cholestrol { get; set; }
        public double Koolhydraten { get; set; }
        public double Suikers { get; set; }
        public double Voedingsvezels { get; set; }
        public double VitamineA { get; set; }
        public double VitamineB1 { get; set; }
        public double VitamineB2 { get; set; }
        public double VitamineB6 { get; set; }
        public double VitamineB11 { get; set; }
        public double VitamineB12 { get; set; }
        public double VitamineC { get; set; }
        public double VitamineD { get; set; }
        public double Natrium { get; set; }
        public double Kalium { get; set; }
        public double Calcium { get; set; }
        public double Fosfor { get; set; }
        public double Ijzer { get; set; }
        public double Magnesium { get; set; }
        public double Koper { get; set; }
        public double Zink { get; set; }

        public string Groep { get; set; }

        public static implicit operator ProductResponse(Product product)
        {
            return new ProductResponse()
            {
                Id = product.Id,
                ProductNaam = product.ProductNaam,
                ProductPortie = product.ProductPortie,
                Beschrijving = product.Beschrijving,
                Gevoelswaarde = product.Gevoelswaarde,
                Gezondheidswaarde = product.Gezondheidswaarde,
                EnergieInKcal = product.EnergieInKcal,
                EnergieInKJoule = product.EnergieInKJoule,
                Water = product.Water,
                Eiwit = product.Eiwit,
                Vet = product.Vet,
                VerzadigdVet = product.VerzadigdVet,
                EnkelvoudigVerzadigdVet = product.EnkelvoudigVerzadigdVet,
                MeervoudigVerzadigdVet = product.MeervoudigVerzadigdVet,
                Cholestrol = product.Cholestrol,
                Koolhydraten = product.Koolhydraten,
                Suikers = product.Suikers,
                Voedingsvezels = product.Voedingsvezels,
                VitamineA = product.VitamineA,
                VitamineB1 = product.VitamineB1,
                VitamineB2 = product.VitamineB2,
                VitamineB6 = product.VitamineB6,
                VitamineB11 = product.VitamineB11,
                VitamineB12 = product.VitamineB12,
                VitamineC = product.VitamineC,
                VitamineD = product.VitamineD,
                Natrium = product.Natrium,
                Kalium = product.Kalium,
                Calcium = product.Calcium,
                Fosfor = product.Fosfor,
                Ijzer = product.Ijzer,
                Magnesium = product.Magnesium,
                Koper = product.Koper,
                Zink = product.Zink,
               Groep = product.Productgroep.ProductgroepNaam,
            };
        }
    }
}
