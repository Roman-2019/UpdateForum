using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CommentService : ForumService<CommentModel, Comment>, ICommentService
    {
        public readonly IMapper _mapper;

        public CommentService(IRepository<Comment> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public CommentModel GetById(int id)
        {
            var commentModel = GetAll().FirstOrDefault(x => x.Id == id);
            return commentModel;
        }

        public override CommentModel Map(Comment model)
        {
            return _mapper.Map<CommentModel>(model);
        }

        public override Comment Map(CommentModel tModel)
        {
            return _mapper.Map<Comment>(tModel);
        }

        public override IEnumerable<CommentModel> Map(IList<Comment> comments)
        {
            return _mapper.Map<IEnumerable<CommentModel>>(comments);
        }

        public override IEnumerable<Comment> Map(IList<CommentModel> commentsModel)
        {
            return _mapper.Map<IEnumerable<Comment>>(commentsModel);
        }
    }
}
