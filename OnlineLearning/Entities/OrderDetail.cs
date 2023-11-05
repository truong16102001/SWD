using System;
using System.Collections.Generic;

namespace OnlineLearning.Entities
{
    public partial class OrderDetail
    {
        public int OrderDetailsId { get; set; }
        public int? CourseId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Cost { get; set; }
        public int? OrderId { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Order? Order { get; set; }
    }
}
