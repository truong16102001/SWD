using Microsoft.EntityFrameworkCore;
using OnlineLearning.Entities;
using OnlineLearning.Repositories;

namespace OnlineLearning.Services
{
    public class QuestionService
    {
        public static List<Question> GetQuestions()
        {
            var listQuestions = new List<Question>();
            try
            {
                using (var context = new OnlineLearningDbContext())
                {
                    listQuestions = context.Questions.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listQuestions;
        }
        public static Question FindQuestionById(int questionId)
        {
            var question = new Question();
            try
            {
                using (var context = new OnlineLearningDbContext())
                {
                    question = context.Questions.SingleOrDefault(x => x.QuestionId == questionId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return question;
        }
        public static void AddQuestion(Question p)
        {
            try
            {
                using (var context = new OnlineLearningDbContext())
                {
                    context.Questions.Add(p);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void UpdateQuestion(Question p)
        {
            try
            {
                using (var context = new OnlineLearningDbContext())
                {
                    var existingQuestion = context.Questions.Find(p.QuestionId);
                    if (existingQuestion != null)
                    {
                        context.Entry(existingQuestion).CurrentValues.SetValues(p);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteQuestion(Question p)
        {
            try
            {
                using (var context = new OnlineLearningDbContext())
                {
                    var p1 = context.Questions.Include(x => x.Answers)
                        .SingleOrDefault(c => c.QuestionId == p.QuestionId);
                    List<HistoryQuestionAttempt> attempts = context.HistoryQuestionAttempts.Where(x => x.QuestionId == p1.QuestionId).ToList();
                    context.HistoryQuestionAttempts.RemoveRange(attempts);
                    foreach(var attempt in p1.Answers.ToList())
                    {
                       p1.Answers.Remove(attempt);
                    }
                    context.Questions.Remove(p1);
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
