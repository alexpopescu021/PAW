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
    public class CartController : Controller
    {
        private readonly PAWDbContext context;
        private readonly SongService songService;
        public CartController(SongService songService, PAWDbContext _context)
        {
            this.songService = songService;
            context = _context;
        }
        public IActionResult Index()
        {
            var list = songService.GetAllSongs();
            ViewBag.products = context.Carts.First().Songs.AsEnumerable();
            foreach(var album in list)
            {
                foreach(var product in ViewBag.products)
                {
                    if (album.Id == product.Id)
                    {
                        product.Price = album.Price;
                        context.SaveChanges();
                    }
                        
                }
            }
            var cart = context.Carts.FirstOrDefault();
            ViewBag.total = cart.total;
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
            context.Carts.FirstOrDefault().Songs.Remove(song);
            song.NumberInCart = 0;
            context.Carts.FirstOrDefault().total -= song.Price;
            context.SaveChanges();
            return RedirectToAction("Index");

            //return PartialView("_RemoveSongPartial", removeData);
        }

        [HttpGet]

        public IActionResult Add([FromRoute] string id)
        {

            RemoveSongViewModel removeViewModel = new RemoveSongViewModel()
            {
                Id = id
            };
            var song = songService.GetSongById(id);
            var cart = context.Carts.FirstOrDefault();


            if (cart.Songs.Any(p => p.Id.ToString() == id))
            {
                song.NumberInCart++;
                context.Carts.FirstOrDefault().total += song.Price;
            }
            context.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpGet]

        public IActionResult Subtract([FromRoute] string id)
        {

            RemoveSongViewModel removeViewModel = new RemoveSongViewModel()
            {
                Id = id
            };
            var song = songService.GetSongById(id);
            var cart = context.Carts.FirstOrDefault();


            if (cart.Songs.Any(p => p.Id.ToString() == id))
            {
                if(song.NumberInCart > 1)
                { 
                    song.NumberInCart--;
                    context.Carts.FirstOrDefault().total -= song.Price;
                }
                
            }
            context.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Finish()
        {
            var total = context.Carts.FirstOrDefault().total;
            var songs = context.Carts.FirstOrDefault().Songs.ToList();
            context.Histories.FirstOrDefault().total = total;
            context.Histories.FirstOrDefault().Songs = songs;
            context.Carts.FirstOrDefault().total = 0;
            context.Carts.FirstOrDefault().Songs.Clear();
            context.SaveChanges();

          

            return RedirectToAction("Index");
        }



    }
}
