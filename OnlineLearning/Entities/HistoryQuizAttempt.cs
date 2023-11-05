using System;
using System.Collections.Generic;

namespace OnlineLearning.Entities
{
    public partial class HistoryQuizAttempt
    {
        public HistoryQuizAttempt()
        {
            HistoryQuestionAttempts = new HashSet<HistoryQuestionAttempt>();
        }

        public int AttemptQuizId { get; set; }
        public int? UserId { get; set; }
        public int? QuizId { get; set; }
        public DateTime? AttemptTime { get; set; }
        public bool? Result { get; set; }

        public virtual Quiz? Quiz { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<HistoryQuestionAttempt> HistoryQuestionAttempts { get; set; }
    }
}
