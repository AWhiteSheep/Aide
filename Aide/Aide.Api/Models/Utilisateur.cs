using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aide.Api.Models
{
    public partial class Utilisateur : IdentityUser
    {
        public Utilisateur() : base()
        {
            UtilisateurQuestionReponse = new HashSet<UtilisateurQuestionReponse>();
        }

        public Utilisateur(string userName) : base(userName)
        {

            UtilisateurQuestionReponse = new HashSet<UtilisateurQuestionReponse>();
        }

        [Key]
        [StringLength(100)]
        public string IdentityKey { get; set; }
        [Required]
        [StringLength(60)]
        public string Id { get; set; }
        public int? IdentityKeyRole { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        [ForeignKey(nameof(IdentityKeyRole))]
        [InverseProperty(nameof(Role.Utilisateur))]
        public virtual Role IdentityKeyRoleNavigation { get; set; }
        [InverseProperty("IdentityKeyUserNavigation")]
        public virtual ICollection<UtilisateurQuestionReponse> UtilisateurQuestionReponse { get; set; }
    }
}
