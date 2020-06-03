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
    public class PictureController : Controller
    {
        private readonly IPictureService _pictureService;
        private readonly IMapper _mapper;

        public PictureController(IPictureService service, IMapper mapper)
        {
            _mapper = mapper;
            _pictureService = service;
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

        // GET: Picture
        public ActionResult Index()
        {
            var allPictures = _pictureService.GetAll();
            var pictures = _mapper.Map<IEnumerable<PictureViewModel>>(allPictures);
            ViewBag.ActiveUserRole = GetActiveUserRole();
            return View(pictures);
        }

        // GET: Picture/Details/5
        public ActionResult Details(int id)
        {
            var pictureModel = _pictureService.GetById(id);
            var pictureViewModel = _mapper.Map<PictureViewModel>(pictureModel);
            ViewBag.ActiveUserRole = GetActiveUserRole();
            return View(pictureViewModel);
        }

        [Authorize(Roles = "admin")]
        // GET: Picture/Create
        public ActionResult Create()
        {
            ViewBag.ActiveUserRole = GetActiveUserRole();
            return View();
        }

        [Authorize(Roles = "admin")]
        // POST: Picture/Create
        [HttpPost]
        public ActionResult Create(PictureViewModel model)
        {
            if (ModelState.IsValid)
            {
                var pictureModel = _mapper.Map<PictureModel>(model);
                _pictureService.Add(pictureModel);
                ViewBag.ActiveUserRole = GetActiveUserRole();
                return RedirectToAction("Index");
            }
            ViewBag.ActiveUserRole = GetActiveUserRole();
            return View();
        }

        [Authorize(Roles = "admin")]
        // GET: Picture/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.ActiveUserRole = GetActiveUserRole();
            return View();
        }

        [Authorize(Roles = "admin")]
        // POST: Picture/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PictureViewModel model)
        {
            if (ModelState.IsValid)
            {
                var pictureModel = _mapper.Map<PictureModel>(model);
                _pictureService.Update(pictureModel);
                ViewBag.ActiveUserRole = GetActiveUserRole();
                return RedirectToAction("Index");
            }
            ViewBag.ActiveUserRole = GetActiveUserRole();
            return View();
        }

        [Authorize(Roles = "admin")]
        // GET: Picture/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.ActiveUserRole = GetActiveUserRole();
            return View();
        }

        [Authorize(Roles = "admin")]
        // POST: Picture/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PictureViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                _pictureService.Remove(id);
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
