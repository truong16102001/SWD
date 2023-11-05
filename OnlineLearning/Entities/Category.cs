using System;
using System.Collections.Generic;

namespace OnlineLearning.Entities
{
    public partial class Category
    {
        public Category()
        {
            Courses = new HashSet<Course>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<Course> Courses { get; set; }
    }
}
