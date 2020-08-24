using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nutritions.Api.DataModels
{
    public class Productgroep
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string ProductgroepNaam { get; set; }



        public  virtual IEnumerable<Product> Producten { get; set; }
    }
}
