using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aide.Api.Models
{
    public partial class UtilisateurRoleView
    {
        [Required]
        [Column("Utilisateur dbo.ID")]
        [StringLength(100)]
        public string UtilisateurDboId { get; set; }
        [Required]
        [Column("N'o utilisateur")]
        [StringLength(60)]
        public string NOUtilisateur { get; set; }
        [Column("N'o role")]
        public int? NORole { get; set; }
        [Column("Role tag")]
        [StringLength(20)]
        public string RoleTag { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        [Column("Addresse email")]
        [StringLength(100)]
        public string AddresseEmail { get; set; }
    }
}
