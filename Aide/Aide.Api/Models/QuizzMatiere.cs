using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aide.Api.Models
{
    public partial class QuizzMatiere
    {
        public QuizzMatiere()
        {
            Quizz = new HashSet<Quizz>();
        }

        [Key]
        
        public int IdentityKey { get; set; }
        [Required]
        public string Titre { get; set; }

        [InverseProperty("IdentityKeyMatiereNavigation")]
        public virtual ICollection<Quizz> Quizz { get; set; }
    }
}
