using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetInternetQuizer.Data
{
    public partial class Role
    {
        public Role()
        {
            Utilisateur = new HashSet<Utilisateur>();
        }

        [Key]
        public int IdentityKey { get; set; }
        [StringLength(20)]
        public string Tag { get; set; }

        [InverseProperty("IdentityKeyRoleNavigation")]
        public virtual ICollection<Utilisateur> Utilisateur { get; set; }
    }
}
