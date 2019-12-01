using Aide.Api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aide.Api.Models
{
    public partial class Role
    {
        public Role()
        {
            Utilisateur = new HashSet<AideWebUser>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(20)]
        public string Tag { get; set; }

        [InverseProperty("IdentityKeyRoleNavigation")]
        public virtual ICollection<AideWebUser> Utilisateur { get; set; }
    }
}
