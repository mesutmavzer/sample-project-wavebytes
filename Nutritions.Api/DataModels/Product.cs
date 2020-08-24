using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Nutritions.Api.DataModels
{
    public class Product
    {
        [Key]
        public Guid Id  { get; set; }
        [Required]
        public string ProductNaam { get; set; }
       
        public double ProductPortie{ get; set; }

        public string  Beschrijving { get; set; }

        [Required]
        public double Gevoelswaarde { get; set; }
        [Required]
        public double Gezondheidswaarde { get; set; }
        [Required]
        public double EnergieInKcal { get; set; }
        [Required]
        public double EnergieInKJoule { get; set; }

        [Required]
        public double Water { get; set; }
        [Required]
        public double Eiwit { get; set; }
        [Required]
        public double Vet { get; set; }
        [Required]
        public double VerzadigdVet { get; set; }
        [Required]
        public double EnkelvoudigVerzadigdVet { get; set; }
        [Required]
        public double MeervoudigVerzadigdVet { get; set; }
        [Required]
        public double Cholestrol { get; set; }
        [Required]
        public double Koolhydraten { get; set; }
        [Required]
        public double Suikers { get; set; }
        [Required]
        public double Voedingsvezels { get; set; }
        [Required]
        public double VitamineA { get; set; }
        [Required]
        public double VitamineB1 { get; set; }
        [Required]
        public double VitamineB2 { get; set; }
        [Required]
        public double VitamineB6 { get; set; }
        [Required]
        public double VitamineB11 { get; set; }
        [Required]
        public double VitamineB12 { get; set; }
        [Required]
        public double VitamineC { get; set; }
        [Required]
        public double VitamineD { get; set; }
        [Required]
        public double Natrium { get; set; }
        [Required]
        public double Kalium { get; set; }
        [Required]
        public double Calcium { get; set; }
        [Required]
        public double Fosfor { get; set; }
        [Required]
        public double Ijzer { get; set; }
        [Required]
        public double Magnesium { get; set; }
        [Required]
        public double Koper { get; set; }
        [Required]
        public double Zink { get; set; }


        [ForeignKey(nameof(Productgroep))]
        public Guid? ProductgroepId { get; set; }
        public virtual Productgroep Productgroep { get; set; }

     
    }
}
