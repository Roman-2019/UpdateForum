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
    public class PictureController : Controller
    {
        private readonly IPictureService _pictureService;
        private readonly IMapper _mapper;

        public PictureController(IPictureService service, IMapper mapper)
        {
            _mapper = mapper;
            _pictureService = service;
        }

        // GET: Picture
        public ActionResult Index()
        {
            var allPictures = _pictureService.GetAll();
            var pictures = _mapper.Map<IEnumerable<PictureViewModel>>(allPictures);
            return View(pictures);
        }

        // GET: Picture/Details/5
        public ActionResult Details(int id)
        {
            var pictureModel = _pictureService.GetById(id);
            var pictureViewModel = _mapper.Map<PictureViewModel>(pictureModel);
            return View(pictureViewModel);
        }

        // GET: Picture/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Picture/Create
        [HttpPost]
        public ActionResult Create(PictureViewModel model)
        {
            if (ModelState.IsValid)
            {
                var pictureModel = _mapper.Map<PictureModel>(model);
                _pictureService.Add(pictureModel);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Picture/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Picture/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PictureViewModel model)
        {
            if (ModelState.IsValid)
            {
                var pictureModel = _mapper.Map<PictureModel>(model);
                _pictureService.Update(pictureModel);

                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Picture/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Picture/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PictureViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                _pictureService.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
