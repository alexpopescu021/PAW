using System;
using System.Text;
using PAW.DataAcess;
using PAW.Model;
using PAWDataAcess.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace PAWDataAcess.Repos
{
    public class EFQuizRepository : EFBaseRepository<Quiz>, IQuizRepository
    {
        public EFQuizRepository(PAWDbContext dbContext) : base(dbContext)
        { }

        public new IEnumerable<Quiz> GetAll()
        {

            return dbContext.Quizzes.AsEnumerable();

        }
        public new Quiz GetById(Guid quizId)
        {
            var Quiz = dbContext.Quizzes.Where(quiz => quiz.Id == quizId).FirstOrDefault();
            return Quiz;
        }

        public bool RemoveQuiz(Guid quizId)
        {
            var entityToRemove = GetById(quizId);

            if (entityToRemove != null)
            {
                dbContext.Remove(entityToRemove);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Quiz UpdateQuiz(Guid quizId)
        {
            throw new NotImplementedException();
        }
    }
}
