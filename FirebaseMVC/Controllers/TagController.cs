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


        // GET: TagController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TagController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tag tag)
        {
            List<Tag> tags = _tagRepo.GetAllTags();

            if (tags.Any(t => t.Name == tag.Name))
            {
                ModelState.AddModelError("", "Tag already exists.");
                return View(tag);
            }
            else
            {
                try
                {
                    _tagRepo.AddTag(tag);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View(tag);
                }
            }
        }

        // GET: TagController/Edit/5
        public ActionResult Edit(int id)
        {
            Tag tag = _tagRepo.GetTagById(id);
            return View(tag);
        }

        // POST: TagController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Tag tag)
        {
            try
            {
                _tagRepo.UpdateTag(tag);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(tag);
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
