using System;
using System.Collections.Generic;

namespace OnlineLearning.Entities
{
    public partial class UserLog
    {
        public int LogId { get; set; }
        public int? UserId { get; set; }
        public string? Action { get; set; }
        public DateTime? ActionTime { get; set; }
        public string LoginIp { get; set; } = null!;

        public virtual User? User { get; set; }
    }
}
