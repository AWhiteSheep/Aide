using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetInternetQuizer.Data
{
    public partial class QuizzQuestionReponsePointView
    {
        [Column("Questionnaire dbo.ID")]
        public int? QuestionnaireDboId { get; set; }
        [Required]
        [Column("Titre questionnaire")]
        [StringLength(100)]
        public string TitreQuestionnaire { get; set; }
        [Column("Question dbo.ID")]
        public int? QuestionDboId { get; set; }
        [Column("Question N'o")]
        public int? QuestionNO { get; set; }
        [Column(TypeName = "text")]
        public string Question { get; set; }
        [Column("Question points attribués")]
        public int? QuestionPointsAttribués { get; set; }
        [Column("Réponse dbo.ID")]
        public int? RéponseDboId { get; set; }
        [Column(TypeName = "text")]
        public string Reponse { get; set; }
        [Column("Bonne/Mauvaise")]
        public bool? BonneMauvaise { get; set; }
    }
}
