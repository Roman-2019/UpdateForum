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
    public class CommentController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ICommentService _commentService;
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public CommentController()
        {

        }
        public CommentController(ICommentService service, IPostService postservice, ICategoryService categoryService, IMapper mapper)
        {
            _mapper = mapper;
            _commentService = service;
            _postService = postservice;
            _categoryService = categoryService;
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

        // GET: Comment
        public ActionResult Index()
        {
            var allComments = _commentService.GetAll();
            var comments = _mapper.Map<IEnumerable<CommentViewModel>>(allComments);
            return View(comments);
        }

        // GET: Comment/Details/5
        public ActionResult Details(int id)
        {
            var commentModel = _commentService.GetById(id);
            var commentViewModel = _mapper.Map<CommentViewModel>(commentModel);
            return View(commentViewModel);
        }

        public ActionResult CommentByPost(int id)
        {
            ViewBag.ActiveUserRole = GetActiveUserRole();
            var allComments = _commentService.GetAll();
            var comments = _mapper.Map<IEnumerable<CommentViewModel>>(allComments);
            if (id != null && id != 0)
            {
                comments = comments.Where(x => x.PostViewModel.Id == id);
            }

            //var allPosts = _postService.GetAll();
            //var posts = _mapper.Map<IEnumerable<PostViewModel>>(allPosts);
            var postModel = _postService.GetById(id);
            var postViewModel = _mapper.Map<PostViewModel>(postModel);
            CommentsPost commentsList = new CommentsPost
            {
                Comments = comments,
                //Posts = new SelectList(posts, "Id", "Title ")
                PostViewModel = postViewModel
            };

            return View(commentsList);
        }

        [Authorize]
        // GET: Comment/Create
        public ActionResult Create()
        {
            var allCategories = _categoryService.GetAll();
            var categories = _mapper.Map<IEnumerable<CategoryViewModel>>(allCategories);
            SelectList selectLists = new SelectList(categories, "Id", "Title");
            ViewBag.Categories = selectLists;
            return View();
        }

        // POST: Comment/Create
        [HttpPost]        
        public ActionResult Create(CommentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var commentModel = _mapper.Map<CommentModel>(model);
                _commentService.Add(commentModel);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Comment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Comment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CommentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var commentModel = _mapper.Map<CommentModel>(model);
                _commentService.Update(commentModel);

                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Comment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Comment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CommentViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                _commentService.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
