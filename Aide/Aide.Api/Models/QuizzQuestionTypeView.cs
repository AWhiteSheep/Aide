using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aide.Api.Models
{
    public partial class QuizzQuestionTypeView
    {
        [Required]
        [Column("Titre questionnaire")]
        [StringLength(100)]
        public string TitreQuestionnaire { get; set; }
        public int IdentityKey { get; set; }
        public int? IdentityKeyMatiere { get; set; }
        [Required]
        [StringLength(100)]
        public string Titre { get; set; }
        [Column(TypeName = "text")]
        public string Description { get; set; }
        [Column(TypeName = "decimal(16, 2)")]
        public decimal? PointTotal { get; set; }
        [Column("Questionnaire dbo.ID")]
        public int? QuestionnaireDboId { get; set; }
        [Column("Question dbo.ID")]
        public int? QuestionDboId { get; set; }
        [Column("N'o")]
        public int? NO { get; set; }
        [Column("Type de question")]
        public string TypeDeQuestion { get; set; }
        [Column(TypeName = "text")]
        public string Question { get; set; }
        [Column("Question points attribués")]
        public int? QuestionPointsAttribués { get; set; }
    }
}
