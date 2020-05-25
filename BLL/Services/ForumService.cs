using BLL.Interfaces;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public abstract class ForumService<TModel, T> : IService<TModel>
        where TModel : class
        where T : class
    {
        public readonly IRepository<T> _repository;

        public ForumService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public void Add(TModel tModel)
        {
            var model = Map(tModel);
            _repository.Add(model);
        }

        public IEnumerable<TModel> GetAll()
        {
            var tModels = _repository.GetAll().ToList();

            return Map(tModels);
        }

        public TModel GetById(int id)
        {
            var tModel = _repository.GetById(id);

            return Map(tModel);
        }

        public void Remove(int id)
        {
            _repository.Remove(id);
        }

        public void Update(TModel tModel)
        {
            var model = Map(tModel);
            _repository.Update(model);
        }

        public abstract TModel Map(T model);
        public abstract T Map(TModel tModel);

        public abstract IEnumerable<TModel> Map(IList<T> models);
        public abstract IEnumerable<T> Map(IList<TModel> tModels);

    }
}
