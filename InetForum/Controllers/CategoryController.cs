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
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService service, IMapper mapper)
        {
            _mapper = mapper;
            _categoryService = service;
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

        // GET: Category
        public ActionResult Index()
        {
            ViewBag.ActiveUserRole = GetActiveUserRole();
            var allCategories = _categoryService.GetAll();
            var categories = _mapper.Map<IEnumerable<CategoryViewModel>>(allCategories);
            return View(categories);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            var categoryModel = _categoryService.GetById(id);
            var categoryViewModel = _mapper.Map<CategoryViewModel>(categoryModel);
            ViewBag.ActiveUserRole = GetActiveUserRole();
            return View(categoryViewModel);
        }

        [Authorize(Roles = "admin")]
        // GET: Category/Create
        public ActionResult Create()
        {
            ViewBag.ActiveUserRole = GetActiveUserRole();
            return View();
        }

        [Authorize(Roles = "admin")]
        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var categoryModel = _mapper.Map<CategoryModel>(model);
                _categoryService.Add(categoryModel);
                ViewBag.ActiveUserRole = GetActiveUserRole();
                return RedirectToAction("Index");
            }
            ViewBag.ActiveUserRole = GetActiveUserRole();
            return View();
        }

        [Authorize(Roles = "admin")]
        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.ActiveUserRole = GetActiveUserRole();
            return View();
        }

        [Authorize(Roles = "admin")]
        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var categoryModel = _mapper.Map<CategoryModel>(model);
                _categoryService.Update(categoryModel);
                ViewBag.ActiveUserRole = GetActiveUserRole();
                return RedirectToAction("Index");
            }
            ViewBag.ActiveUserRole = GetActiveUserRole();
            return View();
        }

        [Authorize(Roles = "admin")]
        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.ActiveUserRole = GetActiveUserRole();
            return View();
        }

        [Authorize(Roles = "admin")]
        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CategoryViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                _categoryService.Remove(id);
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
