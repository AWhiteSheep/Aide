using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aide.Api.Models
{
    public partial class QuizzMatiereView
    {
        public int Identité { get; set; }
        [Required]
        [StringLength(100)]
        public string Nom { get; set; }
        public string Matière { get; set; }
        [Column(TypeName = "text")]
        public string Déscription { get; set; }
    }
}
