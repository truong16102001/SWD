using System;
using System.Collections.Generic;

namespace OnlineLearning.Entities
{
    public partial class Enrollment
    {
        public int CustomerId { get; set; }
        public int CourseId { get; set; }
        public DateTime? EnrollTime { get; set; }
        public int? CompletePercent { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual User Customer { get; set; } = null!;
    }
}
