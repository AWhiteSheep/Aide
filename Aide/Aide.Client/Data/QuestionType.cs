using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetInternetQuizer.Data
{
    public partial class QuestionType
    {
        public QuestionType()
        {
            Question = new HashSet<Question>();
        }

        [Key]
        public int IdentityKey { get; set; }
        public string Nom { get; set; }

        [InverseProperty("IdentityKeyQuestionTypeNavigation")]
        public virtual ICollection<Question> Question { get; set; }
    }
}
