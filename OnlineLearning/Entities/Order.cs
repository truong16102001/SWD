using System;
using System.Collections.Generic;

namespace OnlineLearning.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public int? SellerId { get; set; }
        public decimal? TotalCost { get; set; }
        public DateTime? OrderTime { get; set; }
        public int? StatusOrderId { get; set; }
        public string? PaymentMethod { get; set; }
        public string? Note { get; set; }

        public virtual User? Customer { get; set; }
        public virtual User? Seller { get; set; }
        public virtual StatusOfOrder? StatusOrder { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
