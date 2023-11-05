using System;
using System.Collections.Generic;

namespace OnlineLearning.Entities
{
    public partial class Quiz
    {
        public Quiz()
        {
            HistoryQuizAttempts = new HashSet<HistoryQuizAttempt>();
            Questions = new HashSet<Question>();
        }

        public int QuizId { get; set; }
        public string? Title { get; set; }
        public int? Duration { get; set; }
        public int? TotalQuestion { get; set; }
        public int? PassingScore { get; set; }
        public int? LessonId { get; set; }
        public int? ChapterId { get; set; }

        public virtual Chapter? Chapter { get; set; }
        public virtual Lesson? Lesson { get; set; }
        public virtual ICollection<HistoryQuizAttempt> HistoryQuizAttempts { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
