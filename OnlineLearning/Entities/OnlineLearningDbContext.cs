using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OnlineLearning.Entities
{
    public partial class OnlineLearningDbContext : DbContext
    {
        public OnlineLearningDbContext()
        {
        }

        public OnlineLearningDbContext(DbContextOptions<OnlineLearningDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answers { get; set; } = null!;
        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Chapter> Chapters { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Document> Documents { get; set; } = null!;
        public virtual DbSet<Enrollment> Enrollments { get; set; } = null!;
        public virtual DbSet<HistoryQuestionAttempt> HistoryQuestionAttempts { get; set; } = null!;
        public virtual DbSet<HistoryQuizAttempt> HistoryQuizAttempts { get; set; } = null!;
        public virtual DbSet<Lesson> Lessons { get; set; } = null!;
        public virtual DbSet<Option> Options { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<Quiz> Quizzes { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<StatusOfOrder> StatusOfOrders { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserLog> UserLogs { get; set; } = null!;
        public virtual DbSet<Video> Videos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server =(local); database = OnlineLearningDb;uid=ndt;pwd=16102001;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>(entity =>
            {
                entity.HasKey(e => new { e.OptionId, e.QuestionId })
                    .HasName("PK__Answers__65410E0BF629E9EB");

                entity.Property(e => e.OptionId).HasColumnName("option-id");

                entity.Property(e => e.QuestionId).HasColumnName("question-id");

                entity.Property(e => e.Note).HasColumnName("note");

                entity.HasOne(d => d.Option)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.OptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Answers__option-__4E88ABD4");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Answers__questio__4F7CD00D");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.CartId).HasColumnName("cart-id");

                entity.Property(e => e.Cost)
                    .HasColumnType("money")
                    .HasColumnName("cost");

                entity.Property(e => e.CourseId).HasColumnName("course-id");

                entity.Property(e => e.CustomerId).HasColumnName("customer-id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__Carts__course-id__693CA210");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Carts__customer-__6A30C649");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).HasColumnName("category-id");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(30)
                    .HasColumnName("category-name");
            });

            modelBuilder.Entity<Chapter>(entity =>
            {
                entity.Property(e => e.ChapterId).HasColumnName("chapter-id");

                entity.Property(e => e.CourseId).HasColumnName("course-id");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .HasColumnName("title");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Chapters)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__Chapters__course__403A8C7D");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.CommentId).HasColumnName("comment-id");

                entity.Property(e => e.Content)
                    .HasMaxLength(700)
                    .HasColumnName("content");

                entity.Property(e => e.CourseId).HasColumnName("course-id");

                entity.Property(e => e.LessonId).HasColumnName("lesson-id");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__Comments__course__619B8048");

                entity.HasOne(d => d.Lesson)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.LessonId)
                    .HasConstraintName("FK__Comments__lesson__628FA481");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseId).HasColumnName("course-id");

                entity.Property(e => e.CategoryId).HasColumnName("category-id");

                entity.Property(e => e.CourseDescription).HasColumnName("course-description");

                entity.Property(e => e.CourseName)
                    .HasMaxLength(100)
                    .HasColumnName("course-name");

                entity.Property(e => e.ImageUrl)
                    .IsUnicode(false)
                    .HasColumnName("image_url");

                entity.Property(e => e.IsPublic).HasColumnName("isPublic");

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("last-update");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Courses__categor__3D5E1FD2");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.Property(e => e.DocumentId).HasColumnName("document-id");

                entity.Property(e => e.DocumentUrl)
                    .IsUnicode(false)
                    .HasColumnName("document-url");

                entity.Property(e => e.LessonId).HasColumnName("lesson-id");

                entity.HasOne(d => d.Lesson)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.LessonId)
                    .HasConstraintName("FK__Documents__lesso__5EBF139D");
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.CourseId })
                    .HasName("PK__Enrollme__F924E1B6AE734C77");

                entity.Property(e => e.CustomerId).HasColumnName("customer-id");

                entity.Property(e => e.CourseId).HasColumnName("course-id");

                entity.Property(e => e.CompletePercent).HasColumnName("complete-percent");

                entity.Property(e => e.EnrollTime)
                    .HasColumnType("datetime")
                    .HasColumnName("enroll-time");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Enrollmen__cours__66603565");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Enrollmen__custo__656C112C");
            });

            modelBuilder.Entity<HistoryQuestionAttempt>(entity =>
            {
                entity.HasKey(e => e.AttemptQuestionId)
                    .HasName("PK__HistoryQ__DC3C6D8E891DC723");

                entity.Property(e => e.AttemptQuestionId).HasColumnName("attemptQuestion-id");

                entity.Property(e => e.AttemptQuizId).HasColumnName("attemptQuiz-id");

                entity.Property(e => e.CorrectOptionId).HasColumnName("correct-option-id");

                entity.Property(e => e.IsCorrect).HasColumnName("isCorrect");

                entity.Property(e => e.QuestionId).HasColumnName("question-id");

                entity.Property(e => e.UserOptionId).HasColumnName("user-option-id");

                entity.HasOne(d => d.AttemptQuiz)
                    .WithMany(p => p.HistoryQuestionAttempts)
                    .HasForeignKey(d => d.AttemptQuizId)
                    .HasConstraintName("FK__HistoryQu__attem__5629CD9C");

                entity.HasOne(d => d.CorrectOption)
                    .WithMany(p => p.HistoryQuestionAttemptCorrectOptions)
                    .HasForeignKey(d => d.CorrectOptionId)
                    .HasConstraintName("FK__HistoryQu__corre__59063A47");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.HistoryQuestionAttempts)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK__HistoryQu__quest__571DF1D5");

                entity.HasOne(d => d.UserOption)
                    .WithMany(p => p.HistoryQuestionAttemptUserOptions)
                    .HasForeignKey(d => d.UserOptionId)
                    .HasConstraintName("FK__HistoryQu__user-__5812160E");
            });

            modelBuilder.Entity<HistoryQuizAttempt>(entity =>
            {
                entity.HasKey(e => e.AttemptQuizId)
                    .HasName("PK__HistoryQ__316C4BAFADCB0707");

                entity.Property(e => e.AttemptQuizId).HasColumnName("attemptQuiz-id");

                entity.Property(e => e.AttemptTime)
                    .HasColumnType("datetime")
                    .HasColumnName("attempt-time");

                entity.Property(e => e.QuizId).HasColumnName("quiz-id");

                entity.Property(e => e.Result).HasColumnName("result");

                entity.Property(e => e.UserId).HasColumnName("user-id");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.HistoryQuizAttempts)
                    .HasForeignKey(d => d.QuizId)
                    .HasConstraintName("FK__HistoryQu__quiz-__534D60F1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.HistoryQuizAttempts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__HistoryQu__user-__52593CB8");
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.Property(e => e.LessonId).HasColumnName("lesson-id");

                entity.Property(e => e.ChapterId).HasColumnName("chapter-id");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .HasColumnName("title");

                entity.HasOne(d => d.Chapter)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.ChapterId)
                    .HasConstraintName("FK__Lessons__chapter__4316F928");
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.Property(e => e.OptionId).HasColumnName("option-id");

                entity.Property(e => e.OptionContent).HasColumnName("option-content");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("order-id");

                entity.Property(e => e.CustomerId).HasColumnName("customer-id");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .HasColumnName("note");

                entity.Property(e => e.OrderTime)
                    .HasColumnType("datetime")
                    .HasColumnName("order-time");

                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(50)
                    .HasColumnName("payment-method");

                entity.Property(e => e.SellerId).HasColumnName("seller-id");

                entity.Property(e => e.StatusOrderId).HasColumnName("status-order-id");

                entity.Property(e => e.TotalCost)
                    .HasColumnType("money")
                    .HasColumnName("total-cost");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.OrderCustomers)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Orders__customer__6EF57B66");

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.OrderSellers)
                    .HasForeignKey(d => d.SellerId)
                    .HasConstraintName("FK__Orders__seller-i__6FE99F9F");

                entity.HasOne(d => d.StatusOrder)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StatusOrderId)
                    .HasConstraintName("FK__Orders__status-o__60A75C0F");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.OrderDetailsId)
                    .HasName("PK__OrderDet__6656A8238E6EEBFF");

                entity.Property(e => e.OrderDetailsId).HasColumnName("order-details-id");

                entity.Property(e => e.Cost)
                    .HasColumnType("money")
                    .HasColumnName("cost");

                entity.Property(e => e.CourseId).HasColumnName("course-id");

                entity.Property(e => e.OrderId).HasColumnName("order-id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__OrderDeta__cours__73BA3083");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderDeta__order__5DCAEF64");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.QuestionId).HasColumnName("question-id");

                entity.Property(e => e.QuestionContent).HasColumnName("question-content");

                entity.Property(e => e.QuizId).HasColumnName("quiz-id");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.QuizId)
                    .HasConstraintName("FK__Questions__quiz-__49C3F6B7");
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.Property(e => e.QuizId).HasColumnName("quiz-id");

                entity.Property(e => e.ChapterId).HasColumnName("chapter-id");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.LessonId).HasColumnName("lesson-id");

                entity.Property(e => e.PassingScore).HasColumnName("passing-score");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .HasColumnName("title");

                entity.Property(e => e.TotalQuestion).HasColumnName("total-question");

                entity.HasOne(d => d.Chapter)
                    .WithMany(p => p.Quizzes)
                    .HasForeignKey(d => d.ChapterId)
                    .HasConstraintName("FK__Quizzes__chapter__46E78A0C");

                entity.HasOne(d => d.Lesson)
                    .WithMany(p => p.Quizzes)
                    .HasForeignKey(d => d.LessonId)
                    .HasConstraintName("FK__Quizzes__lesson-__45F365D3");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("role-id");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .HasColumnName("role-name");
            });

            modelBuilder.Entity<StatusOfOrder>(entity =>
            {
                entity.HasKey(e => e.StatusOrderId)
                    .HasName("PK__StatusOf__0891E3F758CC91D8");

                entity.Property(e => e.StatusOrderId).HasColumnName("status-order-id");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ_Users_Email")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("user-id");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.Avatar)
                    .IsUnicode(false)
                    .HasColumnName("avatar");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.EncodedPassword)
                    .IsUnicode(false)
                    .HasColumnName("encodedPassword");

                entity.Property(e => e.FullName)
                    .HasMaxLength(50)
                    .HasColumnName("full-name");

                entity.Property(e => e.IsEnabled).HasColumnName("isEnabled");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.RoleId).HasColumnName("role-id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Users__role-id__38996AB5");
            });

            modelBuilder.Entity<UserLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PK__UserLogs__9FA6BF4331E018DA");

                entity.Property(e => e.LogId).HasColumnName("log-id");

                entity.Property(e => e.Action)
                    .HasMaxLength(500)
                    .HasColumnName("action");

                entity.Property(e => e.ActionTime)
                    .HasColumnType("datetime")
                    .HasColumnName("action-time");

                entity.Property(e => e.LoginIp)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("login-ip");

                entity.Property(e => e.UserId).HasColumnName("user-id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLogs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserLogs__user-i__778AC167");
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.Property(e => e.VideoId).HasColumnName("video-id");

                entity.Property(e => e.LessonId).HasColumnName("lesson-id");

                entity.Property(e => e.VideoUrl)
                    .IsUnicode(false)
                    .HasColumnName("video-url");

                entity.HasOne(d => d.Lesson)
                    .WithMany(p => p.Videos)
                    .HasForeignKey(d => d.LessonId)
                    .HasConstraintName("FK__Videos__lesson-i__5BE2A6F2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
