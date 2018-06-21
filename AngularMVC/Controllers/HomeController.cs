using AngularMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularMVC.Controllers
{
    public class HomeController : Controller
    {
        PeopleListDb _db = new PeopleListDb();
        public ActionResult Index()
        {
            var model = _db.People.Include("ProfilePicture").Include("Country").ToList();

            var model2 = new List<PersonViewModel>();


            foreach (var item in model)
            {
                model2.Add(new PersonViewModel(item));
            }

            //string imgString = Convert.ToBase64String(item.ProfilePicture.Image);
            //table.Add(String.Format("img src=\"data:image/Bmp;base64,{0}\">", imgString));

            return View(model2);
        }

        
        public ActionResult Edit(int id)
        {
            var model = _db.People.Include("Country")
                                  .Include("ProfilePicture").First(x => x.PersonId == id);

            var viewModel = new PersonViewModel(model);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(PersonViewModel person)
        {
            var model = _db.People.First(x => x.PersonId == person.PersonId);
            model.FirstName = person.FirstName;
            model.LastName = person.LastName;
            model.Email = person.Email;
            model.Country = person.Country;
            model.CountryId = person.Country.CountryId;
            model.ProfilePictureId = person.ProfilePictureId;

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public JsonResult GetPerson()
        {
            var result = _db.People.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetPeople()
        {
            var result = _db.People.Include("ProfilePicture")
                                   .Include("Country")
                                   .ToList();

            var model = new List<PersonViewModel>();


            foreach (var item in result)
            {
                model.Add(new PersonViewModel(item));
            }
            return Json(model, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetPictures()
        {
            var result = _db.Images.ToList();

            var model = new List<ImageViewModel>();

            foreach (var item in result)
            {
                model.Add(new ImageViewModel(item));
            }

            return Json(model, JsonRequestBehavior.AllowGet);

        }

        public JsonResult SearchPeople()
        {
            string url = Request.RawUrl;

            List<PersonViewModel> model = Search.FindPeople(url);

            return Json(model, JsonRequestBehavior.AllowGet);

        }
    }
}