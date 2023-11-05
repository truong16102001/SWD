using System;
using System.Collections.Generic;

namespace OnlineLearning.Entities
{
    public partial class Lesson
    {
        public Lesson()
        {
            Comments = new HashSet<Comment>();
            Documents = new HashSet<Document>();
            Quizzes = new HashSet<Quiz>();
            Videos = new HashSet<Video>();
        }

        public int LessonId { get; set; }
        public string? Title { get; set; }
        public int? ChapterId { get; set; }

        public virtual Chapter? Chapter { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<Quiz> Quizzes { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
    }
}
