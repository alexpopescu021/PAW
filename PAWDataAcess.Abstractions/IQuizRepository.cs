using PAW.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PAWDataAcess.Abstractions
{
    public interface IQuizRepository : IBaseRepository<Quiz>
    {
        new IEnumerable<Quiz> GetAll();
        new Quiz GetById(Guid quizId);

        bool RemoveQuiz(Guid quizId);
        Quiz UpdateQuiz(Guid quizId);
    }
}
