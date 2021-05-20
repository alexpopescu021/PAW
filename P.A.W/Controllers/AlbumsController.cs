using AppLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PAW.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAW.Controllers
{
    [Authorize]
    public class AlbumsController : Controller
    {
        private readonly SongService songService;

        public AlbumsController(SongService songService)
        {
            this.songService = songService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SongsTable(string genre)
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
    }
}
