using System;
using System.Collections.Generic;

namespace OnlineLearning.Entities
{
    public partial class User
    {
        public User()
        {
            Carts = new HashSet<Cart>();
            Enrollments = new HashSet<Enrollment>();
            HistoryQuizAttempts = new HashSet<HistoryQuizAttempt>();
            OrderCustomers = new HashSet<Order>();
            OrderSellers = new HashSet<Order>();
            UserLogs = new HashSet<UserLog>();
        }

        public int UserId { get; set; }
        public string? FullName { get; set; }
        public string? Avatar { get; set; }
        public string Email { get; set; } = null!;
        public string EncodedPassword { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public int? RoleId { get; set; }
        public bool IsEnabled { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<HistoryQuizAttempt> HistoryQuizAttempts { get; set; }
        public virtual ICollection<Order> OrderCustomers { get; set; }
        public virtual ICollection<Order> OrderSellers { get; set; }
        public virtual ICollection<UserLog> UserLogs { get; set; }
    }
}
