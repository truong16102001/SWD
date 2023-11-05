using System;
using System.Collections.Generic;

namespace OnlineLearning.Entities
{
    public partial class HistoryQuestionAttempt
    {
        public int AttemptQuestionId { get; set; }
        public int? AttemptQuizId { get; set; }
        public int? QuestionId { get; set; }
        public int? UserOptionId { get; set; }
        public int? CorrectOptionId { get; set; }
        public bool? IsCorrect { get; set; }

        public virtual HistoryQuizAttempt? AttemptQuiz { get; set; }
        public virtual Option? CorrectOption { get; set; }
        public virtual Question? Question { get; set; }
        public virtual Option? UserOption { get; set; }
    }
}
