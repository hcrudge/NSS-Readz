using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Readz.GoogleBooks;
using Readz.GoogleBooks.Models;
using Readz.Models.ViewModels;
using Readz.Repositories;
using System.Security.Claims;
using Microsoft.VisualBasic;

namespace Readz.Controllers
{
    public class BookController : Controller
    {
        private readonly IGoogleBooksService _GBService;
        private readonly IPostRepository _postRepository;

        //Dependency Injection
        public BookController(IGoogleBooksService googleBooksService, IPostRepository postRepository)
        {
            _GBService = googleBooksService;
            _postRepository = postRepository;
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

            
        }

        // GET: BookController/Details/5
        public async Task<ActionResult> Create(string Id)
        {
            var vm = new PostCreateViewModel() { CurrentUserId = GetCurrentUserProfileId() };
            var book = await _GBService.GetBookByGBId(Id);
            vm.Book = book;
            return View(vm);
        }

        [HttpPost]
        public IActionResult CreatePost(PostCreateViewModel vm)
        {
            vm.Post.PublishedOn = DateAndTime.Now;
            vm.Post.UserProfileId = GetCurrentUserProfileId();
            
            _postRepository.Add(vm.Post, vm.Book);
            return RedirectToAction("Index", "Post");
        }








        private int GetCurrentUserProfileId()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }

    }
}
