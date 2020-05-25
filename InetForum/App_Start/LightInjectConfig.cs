using AutoMapper;
using BLL;
using BLL.Interfaces;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using LightInject;
using BLL.Models;

namespace InetForum.App_Start
{
    public static class LightInjectConfig
    {
        public static void Configurate()
        {
            var container = new ServiceContainer();

            container.RegisterControllers(Assembly.GetExecutingAssembly());

            container.EnablePerWebRequestScope();

            var config = new MapperConfiguration(cfg => cfg.AddProfiles(
                 new List<Profile>() { new AutomapperProfile(), new BLLAutomapperProfile() }));

            container.Register(c => config.CreateMapper());

            container = BLLLigthInjectConfig.Configuration(container);

            container.Register<IPostService, PostService>();
            container.Register<IAuthorService, AuthorService>();
            container.Register<ICategoryService, CategoryService>();
            container.Register<ICommentService, CommentService>();
            container.Register<IPictureService, PictureService>();
            container.Register<ITagService, TagService>();

            container.EnableMvc();

        }

    }
}