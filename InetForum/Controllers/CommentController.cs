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
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public CommentController()
        {

        }
        public CommentController(ICommentService service, IPostService postservice, IMapper mapper)
        {
            _mapper = mapper;
            _commentService = service;
            _postService = postservice;
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

        // GET: Comment/Create
        public ActionResult Create()
        {
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
