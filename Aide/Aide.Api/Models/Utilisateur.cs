using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aide.Api.Models
{
    public partial class Utilisateur : IdentityUser
    {
        public Utilisateur() : base()
        {
        }

        public Utilisateur(string userName) : base(userName)
        {
        }
        [Key]
        [StringLength(100)]
        public string IdentityKey { get; set; }
        public int? IdentityKeyRole { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        [ForeignKey(nameof(IdentityKeyRole))]
        [InverseProperty(nameof(Role.Utilisateur))]
        public virtual Role IdentityKeyRoleNavigation { get; set; }
    }
}
