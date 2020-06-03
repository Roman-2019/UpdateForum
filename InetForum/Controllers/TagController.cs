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
    public class TagController : Controller
    {
        private readonly ITagService _tagService;
        private readonly IMapper _mapper;

        public TagController(ITagService service, IMapper mapper)
        {
            _mapper = mapper;
            _tagService = service;
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

        // GET: Tag
        public ActionResult Index()
        {
            var allTags = _tagService.GetAll();
            var tags = _mapper.Map<IEnumerable<TagViewModel>>(allTags);
            ViewBag.ActiveUserRole = GetActiveUserRole();
            return View(tags);
        }

        // GET: Tag/Details/5
        public ActionResult Details(int id)
        {
            var tagModel = _tagService.GetById(id);
            var tagViewModel = _mapper.Map<TagViewModel>(tagModel);
            ViewBag.ActiveUserRole = GetActiveUserRole();
            return View(tagViewModel);
        }

        [Authorize(Roles = "admin")]
        // GET: Tag/Create
        public ActionResult Create()
        {
            ViewBag.ActiveUserRole = GetActiveUserRole();
            return View();
        }

        [Authorize(Roles = "admin")]
        // POST: Tag/Create
        [HttpPost]
        public ActionResult Create(TagViewModel model)
        {
            if (ModelState.IsValid)
            {
                var tagModel = _mapper.Map<TagModel>(model);
                _tagService.Add(tagModel);
                ViewBag.ActiveUserRole = GetActiveUserRole();
                return RedirectToAction("Index");
            }
            ViewBag.ActiveUserRole = GetActiveUserRole();
            return View();
        }

        [Authorize(Roles = "admin")]
        // GET: Tag/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.ActiveUserRole = GetActiveUserRole();
            return View();
        }

        [Authorize(Roles = "admin")]
        // POST: Tag/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TagViewModel model)
        {
            if (ModelState.IsValid)
            {
                var tagModel = _mapper.Map<TagModel>(model);
                _tagService.Update(tagModel);
                ViewBag.ActiveUserRole = GetActiveUserRole();
                return RedirectToAction("Index");
            }
            ViewBag.ActiveUserRole = GetActiveUserRole();
            return View();
        }

        [Authorize(Roles = "admin")]
        // GET: Tag/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.ActiveUserRole = GetActiveUserRole();
            return View();
        }

        [Authorize(Roles = "admin")]
        // POST: Tag/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TagViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                _tagService.Remove(id);
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
