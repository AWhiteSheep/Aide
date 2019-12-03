using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aide.Api.Models
{
    public partial class UtilisateurQuestionReponse
    {
        [Key]
        [StringLength(100)]
        public string IdentityKey { get; set; }
        [Required]
        [StringLength(100)]
        public string IdentityKeyUser { get; set; }
        public int IdentityKeyQuestionReponse { get; set; }
        public int Essaie { get; set; }

        [ForeignKey(nameof(IdentityKeyQuestionReponse))]
        [InverseProperty(nameof(Question.UtilisateurQuestionReponse))]
        public virtual Question IdentityKeyQuestionReponseNavigation { get; set; }
        [ForeignKey(nameof(IdentityKeyUser))]
        [InverseProperty(nameof(AideWebUser.UtilisateurQuestionReponse))]
        public virtual AideWebUser IdentityKeyUserNavigation { get; set; }
    }
}
