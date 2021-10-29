using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Readz.GoogleBooks;
using Readz.GoogleBooks.Models;

namespace Readz.Controllers
{
    public class BookController : Controller
    {
        private readonly IGoogleBooksService _GBService;

        //Dependency Injection
        public BookController(IGoogleBooksService googleBooksService)
        {
            _GBService = googleBooksService;
        }

        // GET: BookController
        public async Task<ActionResult> Index(string QueryString)
        {
            var vm = new QueryViewModel();
            if (QueryString != null)
            {
                var books = await _GBService.GetAllBooks(QueryString);
                vm.Books = books;
                vm.QueryString = QueryString ;
                return View(vm);
            }
            else
            {
                return View(vm);
            }

            //will need to update to pass in the search parameter - 
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }











    }
}
