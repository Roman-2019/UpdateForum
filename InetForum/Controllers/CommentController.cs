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
using PagedList;
using PagedList.Mvc;

namespace InetForum.Controllers
{
    public class CommentController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly ICommentService _commentService;
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public CommentController(ICommentService service, IPostService postservice, IAuthorService authorService, IMapper mapper)
        {
            _mapper = mapper;
            _commentService = service;
            _postService = postservice;
            _authorService = authorService;
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
            ViewBag.ActiveUserRole = GetActiveUserRole();
            return View(comments);
        }

        // GET: Comment/Details/5
        public ActionResult Details(int id)
        {
            var commentModel = _commentService.GetById(id);
            var commentViewModel = _mapper.Map<CommentViewModel>(commentModel);
            ViewBag.ActiveUserRole = GetActiveUserRole();
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
            var postModel = _postService.GetById(id);
            var postViewModel = _mapper.Map<PostViewModel>(postModel);
            CommentsPost commentsList = new CommentsPost
            {
                Comments = comments,
                PostViewModel = postViewModel
            };

            ViewBag.ActiveUserRole = GetActiveUserRole();

            return View(commentsList);
        }

        public ActionResult PaginationComment(int id, int? page) 
        {
            ViewBag.PostId = id;
            ViewBag.ActiveUserRole = GetActiveUserRole();
            var allComments = _commentService.GetAll();
            var comments = _mapper.Map<IEnumerable<CommentViewModel>>(allComments);
            if (id != null && id != 0)
            {
                comments = comments.Where(x => x.PostViewModel.Id == id);
            }
            int PageSize = 2;
            int pageNumber = (page ?? 1);
            return PartialView(comments.ToPagedList(pageNumber,PageSize));
        }

        [Authorize]
        // GET: Comment/Create
        public ActionResult Create(int newPostId, int newAuthorId, DateTime newDataComment)
        {
           
                var userName = User.Identity.Name;
                int pos = userName.LastIndexOf('@');
                userName = userName.Substring(0, pos);

                var allAuthors = _authorService.GetAll();
                var authors = _mapper.Map<IEnumerable<AuthorViewModel>>(allAuthors);

                var findAuthor = authors.FirstOrDefault(x => x.NickName == userName);
                int newIdAutor = findAuthor.Id;

            var newUser = User.Identity.IsAuthenticated;
            if (newUser == true)
            {
                if (findAuthor == null)
                {
                    var newModel = new AuthorViewModel
                    {
                        NickName = userName,
                        Status = "user",
                        CountComments = 0,
                        IdentityId = User.Identity.GetUserId()
                    };
                    var authorModel = _mapper.Map<AuthorModel>(newModel);
                    _authorService.Add(authorModel);
                }
            }
            var newComment = new CommentViewModel();
            newComment.PostViewModelId = newPostId;
            newComment.AuthorViewModelId = newIdAutor;
            newComment.DateTime = newDataComment;

            ViewBag.ActiveUserRole = GetActiveUserRole();
            return View(newComment);
        }

        // POST: Comment/Create
        [HttpPost]
        //[ValidateInput(false)]
        public ActionResult Create(CommentViewModel model)
        {
            model.DateTime = DateTime.Now.Date;
            model.Text = model.Text.Replace("<p>", "").Replace("</p>","");
            //var postId = PostViewModelId;
            if (ModelState.IsValid)
            {
                var commentModel = _mapper.Map<CommentModel>(model);
                _commentService.Add(commentModel);
                return RedirectToAction("CommentByPost", new { controller = "Comment", action = "CommentByPost", id = model.PostViewModelId});
            }
            ViewBag.ActiveUserRole = GetActiveUserRole();
            return View();
        }

        [Authorize(Roles = "admin")]
        // GET: Comment/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.ActiveUserRole = GetActiveUserRole();
            return View();
        }

        [Authorize(Roles = "admin")]
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
            ViewBag.ActiveUserRole = GetActiveUserRole();
            return View();
        }

        [Authorize(Roles = "admin")]
        // GET: Comment/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.ActiveUserRole = GetActiveUserRole();
            return View();
        }

        [Authorize(Roles = "admin")]
        // POST: Comment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CommentViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                _commentService.Remove(id);
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
