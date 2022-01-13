using AppLogic;
using Microsoft.AspNetCore.Mvc;
using PAW.DataAcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAW.Controllers
{
    public class HistoryController : Controller
    {
        private readonly PAWDbContext context;
        private readonly SongService songService;
        public HistoryController(SongService songService, PAWDbContext _context)
        {
            this.songService = songService;
            context = _context;
        }
        public IActionResult Index()
        {
            this.Finish();
            return View();
        }

        [HttpGet]
        public IActionResult Finish()
        {
            var history = context.Histories.FirstOrDefault();

            var list = songService.GetAllSongs();
            ViewBag.products = history.Songs.AsEnumerable();
                 
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
            var cart = history;
            ViewBag.total = cart.total;
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
