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
            string searchCriteria = null;
            var strings = url.Split('/');

            url = null;

            foreach (var item in strings)
            {
                if (item != "Home" && item != "SearchPeople" && item != "")
                {
                    if (item.Contains("?"))
                    {
                        var change = item.Split('?');
                        foreach (var item2 in change)
                        {
                            if (item2 == "FirstName" || item2 == "LastName" || item2 == "Country")
                            {
                                searchCriteria = item2;
                            }
                            else
                            {
                                url = item2;
                            }
                        }

                    }
                    else
                    {
                        url = item;
                    }


                }

                //if (item == "FirstName" || item == "LastName" || item == "Country" )
                //{
                //    searchCriteria = item;
                //}
            }


            var result = new List<Person>();

            if (url == null)
            {
                result = _db.People.Include("ProfilePicture")
                                       .Include("Country").ToList();
            }
            else
            {
                url.ToLower();

                if (searchCriteria != null)
                {
                    if (searchCriteria == "LastName")
                    {
                        result = _db.People.Include("ProfilePicture")
                                           .Include("Country")
                                           .OrderBy(x => x.LastName)
                                           .Where(x => x.FirstName.Contains(url) || x.LastName.Contains(url))
                                           .ToList();
                    }
                    else if (searchCriteria == "Country")
                    {
                        result = _db.People.Include("ProfilePicture")
                                           .Include("Country")
                                           .OrderBy(x => x.CountryId)
                                           .Where(x => x.FirstName.Contains(url) || x.LastName.Contains(url) || x.Country.CountryName.Contains(url))
                                           .ToList();
                    }
                    else
                    {
                        result = _db.People.Include("ProfilePicture")
                       .Include("Country")
                       .OrderBy(x => x.FirstName)
                       .Where(x => x.FirstName.Contains(url) || x.LastName.Contains(url))
                       .ToList();
                    }
                }
                

            }

            var model = new List<PersonViewModel>();

            foreach (var item in result)
            {
                model.Add(new PersonViewModel(item));
            }

            return Json(model, JsonRequestBehavior.AllowGet);

        }
    }
}