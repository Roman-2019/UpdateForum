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
    public class PictureService : ForumService<PictureModel, Picture>, IPictureService
    {
        public readonly IMapper _mapper;

        public PictureService(IRepository<Picture> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public PictureModel GetById(int id)
        {
            var pictureModel = GetAll().FirstOrDefault(x => x.Id == id);
            return pictureModel;
        }

        public override PictureModel Map(Picture model)
        {
            return _mapper.Map<PictureModel>(model);
        }

        public override Picture Map(PictureModel tModel)
        {
            return _mapper.Map<Picture>(tModel);
        }

        public override IEnumerable<PictureModel> Map(IList<Picture> pictures)
        {
            return _mapper.Map<IEnumerable<PictureModel>>(pictures);
        }

        public override IEnumerable<Picture> Map(IList<PictureModel> picturesModel)
        {
            return _mapper.Map<IEnumerable<Picture>>(picturesModel);
        }
    }
}
