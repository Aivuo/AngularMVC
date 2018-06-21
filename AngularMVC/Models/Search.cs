using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularMVC.Models
{
    public static class Search
    {

        public static List<PersonViewModel> FindPeople(string url)
        {
            PeopleListDb _db = new PeopleListDb();

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
                        if (change[0] == "undefined")
                            change[0] = null;

                        if (change.Count() < 2)
                        {
                            searchCriteria = change[0];
                        }
                        else
                        {
                            url = change[0];
                            searchCriteria = change[1];
                        }
                    }
                    else
                    {
                        url = item;
                    }
                }
            }


            var result = new List<Person>();

            if (url == null)
            {
                if (searchCriteria == "Country")
                {
                    result = _db.People.Include("ProfilePicture")
                                           .Include("Country").OrderBy(x => x.Country.CountryName).ToList();
                }
                else if (searchCriteria == "LastName")
                {
                    result = _db.People.Include("ProfilePicture")
                                       .Include("Country").OrderBy(x => x.LastName).ToList();
                }
                else
                {
                    result = _db.People.Include("ProfilePicture")
                                       .Include("Country").OrderBy(x => x.FirstName).ToList();
                }
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
                                           .OrderBy(x => x.Country.CountryName).ThenBy(x => x.FirstName)
                                           .Where(x => x.Country.CountryName.Contains(url))
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

            return model;
        }
    }
}