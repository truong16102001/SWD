using System;
using System.Collections.Generic;

namespace OnlineLearning.Entities
{
    public partial class Document
    {
        public int DocumentId { get; set; }
        public string? DocumentUrl { get; set; }
        public int? LessonId { get; set; }

        public virtual Lesson? Lesson { get; set; }
    }
}
