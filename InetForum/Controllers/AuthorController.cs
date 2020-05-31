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
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorService service, IMapper mapper)
        {
            _mapper = mapper;
            _authorService = service;
        }

        // GET: Author
        public ActionResult Index()
        {
            var allAuthors = _authorService.GetAll();
            var authors = _mapper.Map<IEnumerable<AuthorViewModel>>(allAuthors);
            return View(authors);
        }

        // GET: Author/Details/5
        public ActionResult Details(int id)
        {
            var authorModel = _authorService.GetById(id);
            var authorViewModel = _mapper.Map<AuthorViewModel>(authorModel);
            return View(authorViewModel);
        }

        // GET: Author/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        [HttpPost]
        public ActionResult Create(AuthorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var authorModel = _mapper.Map<AuthorModel>(model);
                _authorService.Add(authorModel);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Author/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Author/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AuthorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var authorModel = _mapper.Map<AuthorModel>(model);
                _authorService.Update(authorModel);

                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Author/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Author/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, AuthorViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                _authorService.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
