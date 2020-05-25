using AutoMapper;
using BLL.Models;
using InetForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InetForum.App_Start
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<PostViewModel, PostModel>()
                .ForMember(x => x.AuthorModel, s => s.MapFrom(x => x.AuthorViewModel))
                .ForMember(x => x.CategoryModel, s => s.MapFrom(x => x.CategoryViewModel))
                .ForMember(x => x.CommentModels, s => s.MapFrom(x => x.CommentViewModels))
                .ReverseMap();
            CreateMap<AuthorViewModel, AuthorModel>().ReverseMap();
            CreateMap<CommentViewModel, CommentModel>()
                .ForMember(x => x.AuthorModel, s => s.MapFrom(x => x.AuthorViewModel))
                .ForMember(x => x.PostModel, s => s.MapFrom(x => x.PostViewModel))
                .ReverseMap();
            CreateMap<TagViewModel, TagModel>().ReverseMap();
            CreateMap<CategoryViewModel, CategoryModel>().ReverseMap();
            CreateMap<PictureViewModel, PictureModel>().ReverseMap();
        }

    }
}