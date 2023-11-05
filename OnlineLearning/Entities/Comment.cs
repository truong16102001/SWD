using System;
using System.Collections.Generic;

namespace OnlineLearning.Entities
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public string? Content { get; set; }
        public int? CourseId { get; set; }
        public int? LessonId { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Lesson? Lesson { get; set; }
    }
}
