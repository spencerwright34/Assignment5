using Assignment5.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IBookstoreRepository repository;

        public NavigationMenuViewComponent (IBookstoreRepository r)
        {
            repository = r;
        }

        public IViewComponentResult Invoke()
        {
            //This will highlight the selected category
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            //This is returning a view listing the Categories in the database 
            return View(repository.Projects
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
