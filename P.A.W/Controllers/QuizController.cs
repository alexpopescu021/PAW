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

            var quiz = new NewQuizViewModel()
            {
                SongList = songService.GetAllSongs().ToList()
            };

            var songs = songService.GetAllSongs();
            List<Song> songList = new List<Song>();

            songList = songs.ToList();

            songList.Insert(0, new Song { Id = new Guid(), Title = "select song" });
            ViewBag.message = songList;
            return View();
        }

        
    }
}
