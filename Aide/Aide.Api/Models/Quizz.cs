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
        public int? IdentityKeyMatiere { get; set; }
        [Required]
        [StringLength(100)]
        public string Titre { get; set; }
        [Column(TypeName = "text")]
        public string Description { get; set; }
        [Column(TypeName = "decimal(16, 2)")]
        public decimal? PointTotal { get; set; }

        [ForeignKey(nameof(IdentityKeyMatiere))]
        [InverseProperty(nameof(QuizzMatiere.Quizz))]
        public virtual QuizzMatiere IdentityKeyMatiereNavigation { get; set; }
        [InverseProperty("IdentityKeyQuizzNavigation")]
        public virtual ICollection<Question> Question { get; set; }
    }
}
