using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aide.Api.Models
{
    public partial class QuestionReponse
    {
        [Key]
        public int IdentityKey { get; set; }
        public int IdentityKeyQuestion { get; set; }
        public int? No { get; set; }
        [Required]
        public bool? Bon { get; set; }
        [Column(TypeName = "text")]
        public string Reponse { get; set; }

        [ForeignKey(nameof(IdentityKeyQuestion))]
        [InverseProperty(nameof(Question.QuestionReponse))]
        public virtual Question IdentityKeyQuestionNavigation { get; set; }
    }
}
