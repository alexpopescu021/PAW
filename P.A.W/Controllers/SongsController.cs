using AppLogic;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAW.ViewModels;
using PAW.ViewModels.Songs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace P.A.W.Controllers
{
    public class SongsController : Controller
    {

        private readonly SongService songService;
        public SongsController(SongService songService)
        {
            this.songService = songService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SongsTable()
        {
            SongListViewModel songViewModel = null;
            try
            {
                songViewModel = new SongListViewModel()
                {
                    SongViews = songService.GetAllSongs()
                };

            }
            catch (Exception e)
            {
               
            }

            return PartialView("_SongsTable", songViewModel);

        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return Content("file not selected");

            var path = Path.Combine(
                         "Assets",
                        file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            var name = file.FileName.ToString();
            string[] file_name = name.Split('_', '.');
            songService.CreateNewSong(file_name[0], "Genre", path, file_name[1]);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Download(string filename)
        {
            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "Assets", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, Path.GetFileName(path));
        }


        [HttpGet]
        public IActionResult Remove([FromRoute] string Id)
        {

            RemoveSongViewModel removeViewModel = new RemoveSongViewModel()
            {
                Id = Id
            };

            return PartialView("_RemoveSongPartial", removeViewModel);
        }

        [HttpPost]
        public IActionResult Remove(RemoveSongViewModel removeData)
        {

            songService.RemoveSong(removeData.Id);


            return RedirectToAction("Index");

            //return PartialView("_RemoveSongPartial", removeData);
        }


        [HttpGet]
        public IActionResult EditSong([FromRoute] string id)
        {
            var song = songService.GetSongById(id);
            NewSongViewModel model = new NewSongViewModel()
            {
                SongId = song.Id,
                Artist = song.Artist,
                Genre = song.Genre,
                Title = song.Title
            }
            ;

            return PartialView("_NewSongPartial", model);

        }

        [HttpPost]
        public ActionResult EditSong([FromForm] NewSongViewModel songData)
        {
            songService.Update(songData.SongId,songData.Artist,songData.Genre, songData.Title);
            return RedirectToAction("Index");
        }


    }

    
}
