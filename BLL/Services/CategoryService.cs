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
    public class CategoryService : ForumService<CategoryModel, Category>, ICategoryService
    {
        public readonly IMapper _mapper;

        public CategoryService(IRepository<Category> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public CategoryModel GetById(int id)
        {
            var categoryModel = GetAll().FirstOrDefault(x => x.Id == id);
            return categoryModel;
        }

        public override CategoryModel Map(Category model)
        {
            return _mapper.Map<CategoryModel>(model);
        }

        public override Category Map(CategoryModel tModel)
        {
            return _mapper.Map<Category>(tModel);
        }

        public override IEnumerable<CategoryModel> Map(IList<Category> categories)
        {
            return _mapper.Map<IEnumerable<CategoryModel>>(categories);
        }

        public override IEnumerable<Category> Map(IList<CategoryModel> categoriesModel)
        {
            return _mapper.Map<IEnumerable<Category>>(categoriesModel);
        }
    }
}
