using System;
using System.Collections.Generic;

namespace OnlineLearning.Entities
{
    public partial class Cart
    {
        public int CartId { get; set; }
        public int? CourseId { get; set; }
        public int? CustomerId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Cost { get; set; }

        public virtual Course? Course { get; set; }
        public virtual User? Customer { get; set; }
    }
}
