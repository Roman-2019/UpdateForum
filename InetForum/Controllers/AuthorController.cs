using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using InetForum.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
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

        public IList<string> GetActiveUserRole()
        {
            IList<string> roles = new List<string> { "Роль не определена" };
            ApplicationUserManager userManager = HttpContext.GetOwinContext()
                                                    .GetUserManager<ApplicationUserManager>();
            ApplicationUser user = userManager.FindByEmail(User.Identity.Name);
            if (user != null)
                roles = userManager.GetRoles(user.Id);
            return new List<string>(roles);
        }

        // GET: Author
        public ActionResult Index()
        {
            var allAuthors = _authorService.GetAll();
            var authors = _mapper.Map<IEnumerable<AuthorViewModel>>(allAuthors);
            ViewBag.ActiveUserRole = GetActiveUserRole();
            return View(authors);
        }

        // GET: Author/Details/5
        public ActionResult Details(int id)
        {
            var authorModel = _authorService.GetById(id);
            var authorViewModel = _mapper.Map<AuthorViewModel>(authorModel);
            ViewBag.ActiveUserRole = GetActiveUserRole();
            return View(authorViewModel);
        }

        // GET: Author/Create
        public ActionResult Create()
        {
            ViewBag.ActiveUserRole = GetActiveUserRole();
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
                ViewBag.ActiveUserRole = GetActiveUserRole();
                return RedirectToAction("Index");
            }
            ViewBag.ActiveUserRole = GetActiveUserRole();
            return View();
        }

        [Authorize(Roles = "admin")]
        // GET: Author/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.ActiveUserRole = GetActiveUserRole();
            return View();
        }

        [Authorize(Roles = "admin")]
        // POST: Author/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AuthorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var authorModel = _mapper.Map<AuthorModel>(model);
                _authorService.Update(authorModel);
                ViewBag.ActiveUserRole = GetActiveUserRole();
                return RedirectToAction("Index");
            }
            ViewBag.ActiveUserRole = GetActiveUserRole();
            return View();
        }

        [Authorize(Roles = "admin")]
        // GET: Author/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.ActiveUserRole = GetActiveUserRole();
            return View();
        }

        [Authorize(Roles = "admin")]
        // POST: Author/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, AuthorViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                _authorService.Remove(id);
                ViewBag.ActiveUserRole = GetActiveUserRole();
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.ActiveUserRole = GetActiveUserRole();
                return View();
            }
        }
    }
}
