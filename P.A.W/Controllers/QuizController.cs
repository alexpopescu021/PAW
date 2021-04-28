using AppLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PAW.Model;
using PAW.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace P.A.W.Controllers
{
    public class QuizController : Controller
    {
        private readonly QuizService quizService;
        private readonly SongService songService;
        public QuizController(QuizService quizService, SongService songService)
        {
            this.quizService = quizService;
            this.songService = songService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult _Quiz()
        {
            QuizListViewModel quizViewModel = null;
            try
            {
                quizViewModel = new QuizListViewModel()
                {
                    QuizViews = quizService.GetAllQuizzes()
                };
                

            }
            catch (Exception e)
            {

            }

            return PartialView("_Quiz",quizViewModel);
        }

        [HttpGet]
        public IActionResult CreateQuiz()
        {
            NewQuizViewModel quiz = new NewQuizViewModel()
            {
                SongList = GetSongList()
            };

            
            return PartialView("_NewQuizPartial", quiz);
        }

        [HttpPost]
        public IActionResult CreateQuiz([FromForm]NewQuizViewModel quizData)
        {
            var song = songService.GetSongById(quizData.SongId);
            quizService.CreateNewQuiz(song, quizData.Answer1, quizData.Answer2, quizData.RightAnswer);
            return RedirectToAction("Index");

        }

        private List<SelectListItem> GetSongList()
        {
            var songs = songService.GetAllSongs();
            List<SelectListItem> songNames = new List<SelectListItem>();

            foreach (var song in songs)
            {
                var text = song.Title;
                songNames.Add(new SelectListItem(text, song.Id.ToString()));
            }
            return songNames;
        }




    }
}
