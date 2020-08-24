using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Nutritions.Api.DataModels
{
    public class Maaltijd
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Beschrijving { get; set; }


        
        
        [ForeignKey(nameof(PersoonlijkDieet))]
        public Guid PersoonlijkDieetId { get; set; }
        public virtual PersoonlijkDieet PersoonlijkDieet { get; set; }

        public  virtual IEnumerable<MaaltijdProduct> Maaltijdproducten { get; set; }
    }
}
