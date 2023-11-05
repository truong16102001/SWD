using System;
using System.Collections.Generic;

namespace OnlineLearning.Entities
{
    public partial class Answer
    {
        public int OptionId { get; set; }
        public int QuestionId { get; set; }
        public string? Note { get; set; }

        public virtual Option Option { get; set; } = null!;
        public virtual Question Question { get; set; } = null!;
    }
}
