using System;
using System.Collections.Generic;

namespace OnlineLearning.Entities
{
    public partial class StatusOfOrder
    {
        public StatusOfOrder()
        {
            Orders = new HashSet<Order>();
        }

        public int StatusOrderId { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
