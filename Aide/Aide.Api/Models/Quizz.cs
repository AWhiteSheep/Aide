using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aide.Api.Models
{
    public partial class Quizz
    {
        public Quizz()
        {
            Question = new HashSet<Question>();
        }

        [Key]
        public int IdentityKey { get; set; }
        [Display(Name = "Matière du quizz")]
        public int? IdentityKeyMatiere { get; set; }
        [Required]
        [StringLength(100)]
        public string Titre { get; set; }
        [Column(TypeName = "text")]
        [Display(Name = "Déscription")]
        public string Description { get; set; }

        [ForeignKey(nameof(IdentityKeyMatiere))]
        [InverseProperty(nameof(QuizzMatiere.Quizz))]
        [Display(Name = "Matière")]
        public virtual QuizzMatiere IdentityKeyMatiereNavigation { get; set; }
        [InverseProperty("IdentityKeyQuizzNavigation")]
        public virtual ICollection<Question> Question { get; set; }
    }
}
