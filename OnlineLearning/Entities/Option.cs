using System;
using System.Collections.Generic;

namespace OnlineLearning.Entities
{
    public partial class Option
    {
        public Option()
        {
            Answers = new HashSet<Answer>();
            HistoryQuestionAttemptCorrectOptions = new HashSet<HistoryQuestionAttempt>();
            HistoryQuestionAttemptUserOptions = new HashSet<HistoryQuestionAttempt>();
        }

        public int OptionId { get; set; }
        public string? OptionContent { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<HistoryQuestionAttempt> HistoryQuestionAttemptCorrectOptions { get; set; }
        public virtual ICollection<HistoryQuestionAttempt> HistoryQuestionAttemptUserOptions { get; set; }
    }
}
