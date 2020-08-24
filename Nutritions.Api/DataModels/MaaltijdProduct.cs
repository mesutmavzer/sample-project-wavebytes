using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Nutritions.Api.DataModels
{
    public class MaaltijdProduct
    {

        [Key]
        public Guid Id { get; set; }
        
        [Required]
        public double AantalInGram { get; set; }


        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey(nameof(Maaltijd))]
        public Guid MaaltijdId { get; set; }
        public virtual Maaltijd Maaltijd { get; set; }
    }
}
