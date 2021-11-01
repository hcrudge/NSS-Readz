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
using Microsoft.VisualBasic;

namespace Readz.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserProfileRepository _userProfileRepository;


        public PostController(IPostRepository postRepository, IUserProfileRepository userProfileRepository)
        {
            _postRepository = postRepository;
            _userProfileRepository = userProfileRepository;
        }




        // GET: PostController
        public IActionResult Index()
        {
            //PostListViewModel is used to pass the current
            //user's id
            var vm = new PostListViewModel() { UserId = GetCurrentUserProfileId() };


            vm.Posts = _postRepository.GetAllPublishedPosts();
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

        public ActionResult MyProfile()
        {
            int userId = GetCurrentUserProfileId();
            var myProfile = _userProfileRepository.GetById(userId);
            var myPosts = _postRepository.GetMyPosts(userId);
            var vm = new PostListViewModel() { Posts = myPosts, UserId = userId, User = myProfile };
            return View(vm);
        }

        public IActionResult Edit(int id)
        {
            var post = _postRepository.GetPublishedPostById(id);

            var vm = new PostDetailsViewModel();


            vm.Post = post;
            vm.Post.PublishedOn = DateAndTime.Now;
            vm.Post.UserProfileId = GetCurrentUserProfileId();

            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(PostDetailsViewModel postDetailsViewModel)
        {
            var post = postDetailsViewModel.Post;

            try
            {
                _postRepository.Update(post);

                return RedirectToAction("Details", new { id = post.Id } );
            }
            catch (Exception ex)
            {
                return View(postDetailsViewModel);
            }
        }


        // POST: PostController/Delete/5
     
        public IActionResult Delete(Post post)
        {
            try
            {
                _postRepository.Delete(post);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Details", new { id = post.Id });
            }
        }

        private int GetCurrentUserProfileId()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }
    }
}
