using System;
using System.Collections.Generic;

namespace OnlineLearning.Entities
{
    public partial class Course
    {
        public Course()
        {
            Carts = new HashSet<Cart>();
            Chapters = new HashSet<Chapter>();
            Comments = new HashSet<Comment>();
            Enrollments = new HashSet<Enrollment>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;
        public string? CourseDescription { get; set; }
        public decimal? Price { get; set; }
        public DateTime? LastUpdate { get; set; }
        public int? CategoryId { get; set; }
        public bool? IsPublic { get; set; }
        public string? ImageUrl { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Chapter> Chapters { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
