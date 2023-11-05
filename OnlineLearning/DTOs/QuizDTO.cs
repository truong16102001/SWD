﻿namespace OnlineLearning.DTOs
{
    public class QuizDTO
    {
        public int QuizId { get; set; }
        public string? Title { get; set; }
        public int? Duration { get; set; }
        public int? TotalQuestion { get; set; }
        public int? PassingScore { get; set; }
        public int? LessonId { get; set; }
        public int? ChapterId { get; set; }
    }
}
