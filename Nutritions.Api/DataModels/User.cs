using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Nutritions.Api.DataModels
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Naam { get; set; }
        [Required]
        [MaxLength(100)]
        public string Voornaam { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }



        [ForeignKey(nameof(PersoonlijkDieet))]
        public Guid? PersoonlijkDieetId { get; set; }
        public virtual PersoonlijkDieet PersoonlijkDieet { get; set; }
    }
}
