﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Readz.Models;
using Readz.Models.ViewModels;
using Readz.Repositories;

namespace Readz.Controllers
{
    public class PostTagController : Controller
    {
        private readonly IPostTagRepository _postTagRepo;
        private readonly ITagRepository _tagRepo;
        private readonly IPostRepository _postRepo;

        public PostTagController(IPostTagRepository postTagRepository, IPostRepository postRepository, ITagRepository tagRepository)
        {
            _postTagRepo = postTagRepository;
            _postRepo = postRepository;
            _tagRepo = tagRepository;
        }
        public ActionResult Create(int id)
        {
            List<Tag> Tags = _tagRepo.GetAllTags();
            List<int> tagsSelected = new List<int>();

            Post post = _postRepo.GetPublishedPostById(id);

            PostTagViewModel pt = new PostTagViewModel
            {
                PostTag = new PostTag(),
                Tag = Tags,
                TagsSelected = tagsSelected,
                PostId = id
            };

            return View(pt);
        }

        // POST: PostTagController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostTagViewModel pt)
        {
            try
            {
                foreach (int tagId in pt.TagsSelected)
                {
                    PostTag postTag = new PostTag
                    {
                        PostId = pt.PostId,
                        TagId = tagId
                    };
                    _postTagRepo.AddPostTag(postTag);
                }
                return RedirectToAction("Details", "Post", new { id = pt.PostId });
            }
            catch
            {
                List<Tag> Tags = _tagRepo.GetAllTags();
                List<int> tagsSelected = new List<int>();

                PostTagViewModel ptvm = new PostTagViewModel
                {
                    PostTag = new PostTag(),
                    Tag = Tags,
                    TagsSelected = tagsSelected,
                    PostId = pt.PostId
                };

                return View(ptvm);
            }
        }

        // GET: PostTagController/Delete/5
        public ActionResult Delete(int id)
        {
            List<PostTag> PostTags = _postTagRepo.GetAllPostTags(id);

            List<int> TagsSelected = new List<int>();
            Post post = _postRepo.GetPublishedPostById(id);

            PostTagViewModel pt = new PostTagViewModel
            {
                PostTag = new PostTag(),
                TagsSelected = TagsSelected,
                PostId = id,
                PostTags = PostTags
            };
            return View(pt);
        }

        // POST: PostTagController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PostTagViewModel pt)
        {
            try
            {
                foreach (int PostTagId in pt.TagsSelected)
                {
                    _postTagRepo.DeletePostTag(PostTagId);
                }
                return RedirectToAction("Details", "Post", new { id = pt.PostId });
            }
            catch
            {
                List<PostTag> PostTags = _postTagRepo.GetAllPostTags(pt.PostId);

                List<int> TagsSelected = new List<int>();
                Post post = _postRepo.GetPublishedPostById(pt.PostId);

                PostTagViewModel ptvm = new PostTagViewModel
                {
                    PostTag = new PostTag(),
                    TagsSelected = TagsSelected,
                    PostId = pt.PostId,
                    PostTags = PostTags
                };
                return View(ptvm);
            }
        }
    }
}


