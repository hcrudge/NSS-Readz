using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Readz.Repositories;
using Readz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Readz.Models.ViewModels;

namespace Readz.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;
        

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }




        // GET: PostController
        public IActionResult Index()
        {
            //PostListViewModel is used to pass the current
            //user's id
            var vm = new PostListViewModel() { UserId = GetCurrentUserProfileId() };

            vm.Posts =  _postRepository.GetAllPublishedPosts();
            return View(vm);
        }

        // GET: PostController/Details/5
        public ActionResult Details(int id)
        {
            int userId = GetCurrentUserProfileId();

            var post = _postRepository.GetPublishedPostById(id);
            if (post == null)
            {
                return NotFound();
            }
            PostDetailsViewModel vm = new PostDetailsViewModel
            {
                Post = post,
                CurrentUserId = userId,
                PostId = id,
            };

            return View(vm);
        }

        // GET: PostController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PostController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private int GetCurrentUserProfileId()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }
    }
}
