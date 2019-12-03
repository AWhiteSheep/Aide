using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetInternetQuizer.Data
{
    public partial class Utilisateur
    {
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
    }
}
