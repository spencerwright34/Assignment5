using Assignment5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Assignment5.Models.ViewModels;

namespace Assignment5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //_repository is created and will eventually be passed to the Index view in order to view the Projects in the database
        private IBookstoreRepository _repository;
        //Variable that will be used to tell how many books we want displayed on each page
        public int PageSize = 5;

        public HomeController(ILogger<HomeController> logger, IBookstoreRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index(string category, int pageNum = 1)
        {
            //This code tells the page which items from the database to display and how many
            return View(new ProjectListViewModel
                {
                    Projects = _repository.Projects
                        //linq is the database language being used to query
                        .Where(p => category == null || p.Category == category)
                        .OrderBy(p => p.BookId)
                        .Skip((pageNum - 1) * PageSize)
                        .Take(PageSize),

                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = pageNum,
                        ItemsPerPage = PageSize,
                        //If category is null, all items will be counted
                        //If a category is selected, the number of books in that specific category are counted
                        TotalNumItems = category == null ? _repository.Projects.Count() :
                            _repository.Projects.Where (x => x.Category == category).Count()
                    },

                    CurrentCategory = category
                });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
