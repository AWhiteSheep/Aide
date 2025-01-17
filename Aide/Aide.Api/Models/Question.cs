﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aide.Api.Models
{
    public partial class Question
    {
        public Question()
        {
            QuestionReponse = new HashSet<QuestionReponse>();
            UtilisateurQuestionReponse = new HashSet<UtilisateurQuestionReponse>();
        }

        [Key]
        public int IdentityKey { get; set; }
        public int IdentityKeyQuizz { get; set; }
        public int? IdentityKeyQuestionType { get; set; }
        public int? Numero { get; set; }
        public int Points { get; set; }
        [Column("Question", TypeName = "text")]
        public string Question1 { get; set; }

        [ForeignKey(nameof(IdentityKeyQuestionType))]
        [InverseProperty(nameof(QuestionType.Question))]
        public virtual QuestionType IdentityKeyQuestionTypeNavigation { get; set; }
        [ForeignKey(nameof(IdentityKeyQuizz))]
        [InverseProperty(nameof(Quizz.Question))]
        public virtual Quizz IdentityKeyQuizzNavigation { get; set; }
        [InverseProperty("IdentityKeyQuestionNavigation")]
        public virtual ICollection<QuestionReponse> QuestionReponse { get; set; }
        [InverseProperty("IdentityKeyQuestionReponseNavigation")]
        public virtual ICollection<UtilisateurQuestionReponse> UtilisateurQuestionReponse { get; set; }
    }
}
