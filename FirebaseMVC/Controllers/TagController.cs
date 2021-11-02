using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Readz.Repositories;
using Readz.Models;
using System.Security.Claims;


namespace Readz.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagRepository _tagRepo;

        public TagController(ITagRepository tagRepository)
        {
            _tagRepo = tagRepository;
        }

        // GET: TagController
        public ActionResult Index()
        {
            List<Tag> tags = _tagRepo.GetAllTags();
            return View(tags);
        }

        // GET: TagController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TagController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TagController/Create
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

        // GET: TagController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TagController/Edit/5
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

       

     
       
        public ActionResult Delete(Tag tag)
        {
            try
            {
                _tagRepo.DeleteTag(tag.Id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View("Index");
            }
        }
    }
}
