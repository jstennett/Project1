using Project_1.Models;
using Project_1.Services;
using Project_1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Project_1.DAL;
using System.Data.Entity;
using System.Web.Security;

namespace Project_1.Controllers
{
    //IS 403 Sec 2
    //Authors: Jordan Stennett, Hunter Muse, Hayden Davis, Scotty Pugmire

    public class HomeController : Controller
    {
        private MarvelContext db = new MarvelContext();

        /*
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
        */
  
        public ActionResult Index()
        {
            /*
            foreach (Avenger item in avengers)
            {
                Character character = Marvel.getAvengers(item.AvengerId);

                CharacterDB characterDB = new CharacterDB()
                {
                    CharacterID = character.Id,
                    Description = character.Description,
                    Name = character.Name,
                    ThumbnailURL = (character.Thumbnail.Path + "." + character.Thumbnail.Extension),
                    URL = character.Urls[character.Urls.FindIndex(x => x.Type == "wiki")].URL
                };

                db.Characters.Add(characterDB);
                db.SaveChanges();
            }
            */

            return View(db.Characters.ToList());
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

            if (character == null)
            {
                ViewBag.ErrorMessage = true;

                return View("SearchCharacter");
            }

            return View("SearchCharacter", character);
        }

        [Authorize]
        public ActionResult AddCharacter(int id)
        {
            if (!db.Characters.Any(x => x.CharacterID == id))
            {
                Character tempCharacter = Marvel.getAvengers(id);

                db.Characters.Add(new CharacterDB
                {
                    CharacterID = id,
                    Description = tempCharacter.Description,
                    Name = tempCharacter.Name,
                    ThumbnailURL = (tempCharacter.Thumbnail.Path + "." + tempCharacter.Thumbnail.Extension),
                    URL = tempCharacter.Urls[tempCharacter.Urls.FindIndex(x => x.Type == "wiki")].URL
                });

                db.SaveChanges();
            }

            return View("Index", db.Characters.ToList());
        }

        public ActionResult Character(int id)
        {

            return View("Character", db.Characters.Where(x => x.CharacterID == id).FirstOrDefault());
        }

        [Authorize]
        public ActionResult CreateCharacter()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateCharacter(CharacterDB character)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateCharacter");
            }

            if (db.Characters.Any(x => x.Name == character.Name))
            {
                return View("Index", db.Characters.ToList());
            }

            Random random = new Random();
            int i = random.Next(2000);

            CharacterDB newCharacter = new CharacterDB()
            {
                Name = character.Name,
                Description = character.Description,
                CharacterID = i,
                ThumbnailURL = character.ThumbnailURL,
                URL = character.URL
            };

            db.Characters.Add(newCharacter);
            db.SaveChanges();
            return View("Index", db.Characters.ToList());
        }

        [Authorize]
        public ActionResult DeleteCharacter(int id)
        {
            if (db.Characters.Any(x => x.CharacterID == id))
            {
                db.Characters.Remove(db.Characters.Where(x => x.CharacterID == id).FirstOrDefault());

                db.SaveChanges();
                return View("Index", db.Characters.ToList());
            }

            return View("Index", db.Characters.ToList());
        }

        [Authorize]
        public ActionResult EditCharacter(int id)
        {
            CharacterDB character = db.Characters.Find(id);


            return View(character);
        }

        [HttpPost]
        public ActionResult EditCharacter(CharacterDB character, int id)
        {
            if (ModelState.IsValid)
            {
                db.Entry(character).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(character);
        }

        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password, bool rememberMe = false)
        {
            string Email = email;
            string Password = password;

            if (db.Users.Any(x => x.Email == Email))
            {
                if (db.Users.SingleOrDefault(x => x.Email == Email).Password == Password)
                {
                    FormsAuthentication.SetAuthCookie(Email, false);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                ViewBag.ErrorMessage = true;
                return View();
            }

            
        }

        public ActionResult SignUp ()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserDB user)
        {
            if (ModelState.IsValid)
            {
                return View(user);
            }

                db.Users.Add(user);
            db.SaveChanges();

            FormsAuthentication.SetAuthCookie(user.Email, false);

            return RedirectToAction("Index", "Home");
        }
    }
}