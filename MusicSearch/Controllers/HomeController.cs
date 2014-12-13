using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicSearch.Core.Data.Repositories;
using MusicSearch.Core.Data.Schema;

namespace MusicSearch.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string search)
        {
            var musics = new List<SongAndArtist>();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var repository = new SearchRepository();
                musics = repository.Search(search);
                musics = musics.OrderBy(s => s.Artist).ThenBy(s => s.Name).ToList();
            }

            return View(musics);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}