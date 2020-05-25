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
    public class AuthorService : ForumService<AuthorModel, Author>, IAuthorService
    {
        public readonly IMapper _mapper;

        public AuthorService(IRepository<Author> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public AuthorModel GetById(int id)
        {
            var authorModel = GetAll().FirstOrDefault(x => x.Id == id);
            return authorModel;
        }

        public override AuthorModel Map(Author model)
        {
            return _mapper.Map<AuthorModel>(model);
        }

        public override Author Map(AuthorModel tModel)
        {
            return _mapper.Map<Author>(tModel);
        }

        public override IEnumerable<AuthorModel> Map(IList<Author> authors)
        {
            return _mapper.Map<IEnumerable<AuthorModel>>(authors);
        }

        public override IEnumerable<Author> Map(IList<AuthorModel> authorsModel)
        {
            return _mapper.Map<IEnumerable<Author>>(authorsModel);
        }

    }
}
