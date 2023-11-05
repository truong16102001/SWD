using System;
using System.Collections.Generic;

namespace OnlineLearning.Entities
{
    public partial class Video
    {
        public int VideoId { get; set; }
        public string? VideoUrl { get; set; }
        public int? LessonId { get; set; }

        public virtual Lesson? Lesson { get; set; }
    }
}
