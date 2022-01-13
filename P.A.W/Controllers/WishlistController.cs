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

namespace PAW.Controllers
{
    public class WishlistController : Controller
    {
        private readonly PAWDbContext context;
        private readonly SongService songService;
        public WishlistController(SongService songService, PAWDbContext _context)
        {
            this.songService = songService;
            context = _context;
        }
        public IActionResult Index()
        {
            var list = songService.GetAllSongs();
            ViewBag.products = context.Wishlist.FirstOrDefault().Songs.AsEnumerable();
            foreach (var album in list)
            {
                foreach (var product in ViewBag.products)
                {
                    if (album.Id == product.Id)
                    {
                        product.Price = album.Price;
                        context.SaveChanges();
                    }

                }
            }
            var Wishlist = context.Wishlist.FirstOrDefault();
           
            context.SaveChanges();


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

            var song = songService.GetSongById(removeData.Id);
            context.Wishlist.FirstOrDefault().Songs.Remove(song);
           
            context.SaveChanges();
            return RedirectToAction("Index");

            //return PartialView("_RemoveSongPartial", removeData);
        }
    }
}
