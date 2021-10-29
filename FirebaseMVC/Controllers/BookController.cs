using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Readz.GoogleBooks;

namespace Readz.Controllers
{
    public class BookController : Controller
    {
        private readonly IGoogleBooksService _GBService;

        //Dependency Injection
        public BookController (IGoogleBooksService googleBooksService)
        {
            _GBService = googleBooksService;
        }

        // GET: BookController
        public async Task<ActionResult> Index()
        {
            //will need to update to pass in the search parameter - 
            var books = await _GBService.GetAllBooks("Harry Potter");
            return View();
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        

       

        

        


        
    }
}
