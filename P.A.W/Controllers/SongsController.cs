using AppLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAW.DataAcess;
using PAW.Model;
using PAW.ViewModels;
using PAW.ViewModels.Songs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace P.A.W.Controllers
{
    [Authorize]
    public class SongsController : Controller
    {
        
        private readonly SongService songService;
        private readonly PAWDbContext context;
        public SongsController(SongService songService, PAWDbContext _context)
        {
            this.songService = songService;
            context = _context;
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

        [HttpGet]
        public IActionResult SongsTableGenre(string genre)
        {
            SongListViewModel songViewModel = null;
            try
            {
                songViewModel = new SongListViewModel()
                {
                    SongViews = songService.GetSongsByGenre(genre)
                };

            }
            catch (Exception e)
            {

            }

            return View("_SongsTable", songViewModel);
        }

        //[HttpPost]
        //public async Task<IActionResult> UploadFile(IFormFile file)
        //{
        //    if (file == null || file.Length == 0)
        //        return Content("file not selected");

        //    var path = Path.Combine(
        //                 "Assets",
        //                file.FileName);

        //    using (var stream = new FileStream(path, FileMode.Create))
        //    {
        //        await file.CopyToAsync(stream);
        //    }
        //    var name = file.FileName.ToString();
        //    string[] file_name = name.Split('_', '.');
        //    songService.CreateNewSong(file_name[0], "Genre", path, file_name[1],1.00m);

        //    return RedirectToAction("Index");
        //}

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
            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "Assets", song.Path);
   
            NewSongViewModel model = new NewSongViewModel()
            {
                SongId = song.Id,
                Artist = song.Artist,
                Genre = song.Genre,
                Title = song.Title,
                Price = song.Price,
                file = path
            }
            ;

            return PartialView("_NewSongPartial", model);

        }

        [HttpPost]
        public ActionResult EditSong([FromForm] NewSongViewModel songData)
        {
            
            var cart = context.Carts.FirstOrDefault();
            var song = cart.Songs.Where(p => p.Id == songData.SongId).FirstOrDefault();
            if (song != null)
            { 
                cart.total -= song.Price;
                song.Price = songData.Price;
                cart.total += song.Price;
            }
           
            if (songData.file == null)
            {
                songService.Update(songData.SongId, songData.Artist, songData.Genre, songData.Title, songData.Price);
            }
            else
            {
                var path = Path.Combine(
                           "Assets", songData.file);
                songService.Update(songData.SongId, songData.Artist, songData.Genre, songData.Title, songData.Price, path);
            }



            
            context.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult NewSong()
        {

            return PartialView("_NewSongPartial", new NewSongViewModel());
        }

        [HttpPost]
        public IActionResult NewSong([FromForm] NewSongViewModel songData)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var path = Path.Combine(
                                    "Assets",
                                    songData.file);
                    songService.CreateNewSong(songData.Title, songData.Artist, songData.Genre, songData.Price, path);
                    //return RedirectToAction("Index");
                }
                return RedirectToAction("Index");

            }
            catch (Exception e) { return BadRequest(e.Message); }

        }


        [HttpGet]
        public IActionResult AddToCart([FromRoute] string id)
        {
            
            RemoveSongViewModel removeViewModel = new RemoveSongViewModel()
            {
                Id = id
            };
            var song = songService.GetSongById(id);
            var cart = context.Carts.FirstOrDefault();

            cart.Songs.Add(song);
            if(cart.Songs.Any(p => p.Id.ToString() == id))
            {
                song.NumberInCart++;
            }
            cart.total += song.Price;
            context.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult AddToWishlist([FromRoute] string id)
        {

            RemoveSongViewModel removeViewModel = new RemoveSongViewModel()
            {
                Id = id
            };
            var song = songService.GetSongById(id);
            var wishlist = context.Wishlist.FirstOrDefault();

            wishlist.Songs.Add(song);
            
            context.SaveChanges();

            return RedirectToAction("Index");

        }

        



    }

    
}
