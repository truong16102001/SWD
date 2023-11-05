using Microsoft.EntityFrameworkCore;
using OnlineLearning.Entities;

namespace OnlineLearning.Services
{
    public class QuizService
    {
        public static List<Quiz> GetQuizzes()
        {
            var listQuizs = new List<Quiz>();
            try
            {
                using (var context = new OnlineLearningDbContext())
                {
                    listQuizs = context.Quizzes.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listQuizs;
        }
        public static Quiz FindQuizById(int QuizId)
        {
            var Quiz = new Quiz();
            try
            {
                using (var context = new OnlineLearningDbContext())
                {
                    Quiz = context.Quizzes.SingleOrDefault(x => x.QuizId == QuizId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return Quiz;
        }
        public static void AddQuiz(Quiz p)
        {
            try
            {
                using (var context = new OnlineLearningDbContext())
                {
                    context.Quizzes.Add(p);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void UpdateQuiz(Quiz p)
        {
            try
            {
                using (var context = new OnlineLearningDbContext())
                {
                    var existingQuiz = context.Quizzes.Find(p.QuizId);
                    if (existingQuiz != null)
                    {
                        context.Entry(existingQuiz).CurrentValues.SetValues(p);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteQuiz(Quiz p)
        {
            try
            {
                using (var context = new OnlineLearningDbContext())
                {
                    var p1 = context.Quizzes.Include(x => x.Questions)
                        .SingleOrDefault(c => c.QuizId == p.QuizId);
                    foreach (var question in p1.Questions.ToList())
                    {
                        QuestionService.DeleteQuestion(question);
                    }
                    List<HistoryQuizAttempt> attempts = context.HistoryQuizAttempts.Where(x => x.QuizId == p1.QuizId).ToList();
                    context.HistoryQuizAttempts.RemoveRange(attempts);
                    context.Quizzes.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
