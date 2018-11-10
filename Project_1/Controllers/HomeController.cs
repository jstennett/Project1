using Project_1.Models;
using Project_1.Services;
using Project_1.ViewModels;
using Project_1.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_1.Controllers
{
    public class HomeController : Controller
    {
        public static List<Avenger> avengers = new List<Avenger>();
        public static LandingPage landingPage = new LandingPage();

        public ActionResult Index()
        {
            //blackwidow
            avengers.Add(new Avenger { AvengerId = 1009189 });
            //captain america
            avengers.Add(new Avenger { AvengerId = 1009220 });
            // Hulk
            avengers.Add(new Avenger { AvengerId = 1009351 });
            //Doctor Strange
            avengers.Add(new Avenger { AvengerId = 1009282 });
            // hawkeye
            avengers.Add(new Avenger { AvengerId = 1009338 });
            // thor
            avengers.Add(new Avenger { AvengerId = 1009664 });
            //spider man
            avengers.Add(new Avenger { AvengerId = 1009610 });
            
            if (avengers.Count() > 1 && landingPage.heroes.Count() < 1)
            {
                foreach (Avenger item in avengers)
                {
                    IRestResponse<CharacterResult> result = Marvel.getAvengers(item.AvengerId);

                    landingPage.heroes.Add(result);
                }
            }
            
            return View(landingPage);
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

        public ActionResult SearchCharacter()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SearchCharacter(String characterName)
        {
            if (landingPage.heroes.Select(x => x.Data.Data.Results.Where(y => y.Name == characterName)));
            {

            }
            IRestResponse<CharacterResult> response = Marvel.searchAvengers(characterName);

            return View("SearchCharacter", response);
        }

        public ActionResult AddCharacter(int id)
        {
            landingPage.heroes.Add(Marvel.getAvengers(id));

            return View("Index", landingPage);
        }

        public ActionResult Character(int id)
        {
            IRestResponse<CharacterResult> result = Marvel.getAvengers(id);

            return View("Character", result);
        }
    }
}