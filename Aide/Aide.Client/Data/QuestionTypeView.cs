using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetInternetQuizer.Data
{
    public partial class QuestionTypeView
    {
        [Column("Questionnaire dbo.ID")]
        public int QuestionnaireDboId { get; set; }
        [Column("Question dbo.ID")]
        public int QuestionDboId { get; set; }
        [Column("N'o")]
        public int? NO { get; set; }
        [Column("Type de question")]
        public string TypeDeQuestion { get; set; }
        [Column(TypeName = "text")]
        public string Question { get; set; }
        [Column("Question points attribués")]
        public int QuestionPointsAttribués { get; set; }
    }
}
