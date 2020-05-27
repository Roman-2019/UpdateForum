using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using InetForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InetForum.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService _tagService;
        private readonly IMapper _mapper;

        public TagController(ITagService service, IMapper mapper)
        {
            _mapper = mapper;
            _tagService = service;
        }

        // GET: Tag
        public ActionResult Index()
        {
            var allTags = _tagService.GetAll();
            var tags = _mapper.Map<IEnumerable<TagViewModel>>(allTags);
            return View(tags);
        }

        // GET: Tag/Details/5
        public ActionResult Details(int id)
        {
            var tagModel = _tagService.GetById(id);
            var tagViewModel = _mapper.Map<TagViewModel>(tagModel);
            return View(tagViewModel);
        }

        // GET: Tag/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tag/Create
        [HttpPost]
        public ActionResult Create(TagViewModel model)
        {
            if (ModelState.IsValid)
            {
                var tagModel = _mapper.Map<TagModel>(model);
                _tagService.Add(tagModel);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Tag/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tag/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TagViewModel model)
        {
            if (ModelState.IsValid)
            {
                var tagModel = _mapper.Map<TagModel>(model);
                _tagService.Update(tagModel);

                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Tag/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tag/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TagViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                _tagService.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
