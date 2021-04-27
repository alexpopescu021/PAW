using PAWDataAcess.Abstractions;
using PAW.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppLogic
{
    public class QuizService
    {
        private readonly IPersistanceContext persistanceContext;
        private readonly IQuizRepository quizRepository;

        public QuizService(IPersistanceContext persistanceContext)
        {
            quizRepository = persistanceContext.QuizRepository;
            this.persistanceContext = persistanceContext;
        }

        public Quiz GetQuizById(string quizId)
        {
            Guid.TryParse(quizId, out Guid guid);
            var quiz = quizRepository?.GetById(guid);

            if (quiz == null)
            {
                throw new Exception();
            }

            return quiz;
        }

        public IEnumerable<Quiz> GetAllQuizzes()
        {
            return quizRepository.GetAll();
        }

        public Quiz CreateNewQuiz(Song song, string answer1, string answer2, string rightAnswer)
        {
            var quiz = Quiz.Create(song, answer1,answer2,rightAnswer);
            quiz = quizRepository.Add(quiz);
            persistanceContext.SaveChanges();

            return quiz;
        }

        public void RemoveQuiz(string id)
        {
            Guid idToSearch = Guid.Parse(id);
            quizRepository.Remove(idToSearch);
            persistanceContext.SaveChanges();
        }
    }
}
