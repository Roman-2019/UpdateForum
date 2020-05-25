using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BLL
{
    public class Mapping<ModelDL, ModelBL> where ModelBL : class where ModelDL : class
    {
        public ModelDL Map(ModelBL modelBL)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ModelBL, ModelDL>());
            var mapper = new Mapper(config);
            ModelDL model = mapper.Map<ModelBL, ModelDL>(modelBL);

            return model;
        }

        public ModelBL Map(ModelDL modelDL)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ModelDL, ModelBL>());
            var mapper = new Mapper(config);
            ModelBL model = mapper.Map<ModelDL, ModelBL>(modelDL);

            return model;
        }

        public IEnumerable<ModelBL> MapList(IList<ModelDL> modelDL)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ModelDL, ModelBL>());
            var mapper = new Mapper(config);
            IEnumerable<ModelBL> models = mapper.Map<IList<ModelDL>, IList<ModelBL>>(modelDL);

            return models;
        }

        public IEnumerable<ModelDL> MapList(IList<ModelBL> modelBL)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ModelBL, ModelDL>());
            var mapper = new Mapper(config);
            IEnumerable<ModelDL> models = mapper.Map<IList<ModelBL>, IList<ModelDL>>(modelBL);

            return models;
        }


    }
}
