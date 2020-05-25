using AutoMapper;
using BLL.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLAutomapperProfile : Profile
    {
        public BLLAutomapperProfile()
        {
            CreateMap<PostModel, Post>()
                .ForMember(x => x.Category, y => y.MapFrom(x => x.CategoryModel))
                .ForMember(x => x.Author, y => y.MapFrom(x => x.AuthorModel))
                //.ForMember(x => x.Comments, y => y.MapFrom(x => x.CommentModels))
                .ForMember(x => x.Comments, y => y.MapFrom(x => x.CommentModels.ToList()))
                .ReverseMap();

            CreateMap<CategoryModel, Category>().ReverseMap();
            CreateMap<CommentModel, Comment>()
                .ForMember(x => x.Post, y => y.MapFrom(x => x.PostModel))
                .ForMember(x => x.Author, y => y.MapFrom(x => x.AuthorModel))
                .ReverseMap();

            CreateMap<AuthorModel, Author>().ReverseMap();
            CreateMap<PictureModel, Picture>().ReverseMap();
            CreateMap<TagModel, Tag>().ReverseMap();
        }

    }
}
