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
    public class PostService : ForumService<PostModel, Post>, IPostService
    {
        public readonly IMapper _mapper;

        public PostService(IRepository<Post> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public PostModel GetById(int id)
        {
            var postModel = GetAll().FirstOrDefault(x => x.Id == id);
            return postModel;
        }

        public IEnumerable<PostModel> Posts()
        {
            var posts = _repository.GetAll()
                .OrderByDescending(x => x.DateTime)
                .ToList();

            var postsModel = Map(posts);

            return postsModel;

        }


        public override PostModel Map(Post model)
        {
            return _mapper.Map<PostModel>(model);
        }

        public override Post Map(PostModel tModel)
        {
            return _mapper.Map<Post>(tModel);
        }

        public override IEnumerable<PostModel> Map(IList<Post> posts)
        {
            return _mapper.Map<IEnumerable<PostModel>>(posts);
        }

        public override IEnumerable<Post> Map(IList<PostModel> postsModel)
        {
            return _mapper.Map<IEnumerable<Post>>(postsModel);
        }
    }
}
