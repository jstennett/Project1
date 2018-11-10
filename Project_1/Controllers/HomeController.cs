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
        public static List<Avenger> avengers = new List<Avenger>() {
            //blackwidow
            new Avenger { AvengerId = 1009189 },
            //captain america
            new Avenger { AvengerId = 1009220 },
            // Hulk
            new Avenger { AvengerId = 1009351 },
            //Doctor Strange
            new Avenger { AvengerId = 1009282 },
            // hawkeye
            new Avenger { AvengerId = 1009338 },
            // thor
            new Avenger { AvengerId = 1009664 },
            //spider man
            new Avenger { AvengerId = 1009610 },
    };
        public static LandingPage landingPage = new LandingPage();

        public ActionResult Index()
        {
            if (avengers.Count() > 1 && landingPage.characters.Count() < 1)
            {
                foreach (Avenger item in avengers)
                {
                    Character character = Marvel.getAvengers(item.AvengerId);
                    
                    landingPage.characters.Add(character);
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
            Character character = Marvel.searchAvengers(characterName);

            return View("SearchCharacter", character);
        }

        public ActionResult AddCharacter(int id)
        {
            if (!landingPage.characters.Exists(x => x.Id == id))
            {
                landingPage.characters.Add(Marvel.getAvengers(id));
            }

            return View("Index", landingPage);
        }

        public ActionResult Character(int id)
        {
            Character character = Marvel.getAvengers(id);

            return View("Character", character);
        }
    }
}