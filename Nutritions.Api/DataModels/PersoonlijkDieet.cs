using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Nutritions.Api.DataModels
{
    public class PersoonlijkDieet
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Beschrijving { get; set; }


       
       

        [ForeignKey(nameof(User))]
        public Guid? UserId { get; set; }
        public virtual User User { get; set; }

        public virtual IEnumerable<Maaltijd> Maaltijden { get; set; }
    }
}
