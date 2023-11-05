using System;
using System.Collections.Generic;

namespace OnlineLearning.Entities
{
    public partial class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
            HistoryQuestionAttempts = new HashSet<HistoryQuestionAttempt>();
        }

        public int QuestionId { get; set; }
        public string QuestionContent { get; set; } = null!;
        public int? QuizId { get; set; }

        public virtual Quiz? Quiz { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<HistoryQuestionAttempt> HistoryQuestionAttempts { get; set; }
    }
}
