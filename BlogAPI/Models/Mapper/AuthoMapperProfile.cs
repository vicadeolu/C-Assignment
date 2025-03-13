using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTO.CommentDTO;
using Domain.DTO.LikesDTO;
using Domain.DTO.PostDTO;
using Domain.DTO.TagDTO;
using Domain.DTO.UserDTO;
using Domain.Models;

namespace BusinessLogicLayer.Mapper
{
    
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                // User Mapping
                CreateMap<Users, UserDto>().ReverseMap();
                CreateMap<CreateRequestUserDto, Users>();
                CreateMap<UpdateRequestUserDto, Users>();

                // BlogPost Mapping
                CreateMap<BlogPost, PostDto>().ReverseMap();
                CreateMap<CreatePostRequestDto, BlogPost>();
                CreateMap<UpdatePostRequestDto, BlogPost>();

                // Likes Mapping
                CreateMap<Likes, LikesDto>().ReverseMap();
                //CreateMap<CreateRequestLikesDto, Likes>();

            // Comments Mapping
            CreateMap<Comments, CommentDto>().ReverseMap();
                CreateMap<CreateCommentRequestDto, Comments>();
                CreateMap<UpdateCommentRequestDto, Comments>();

                // Tags Mapping
                CreateMap<Tags, TagDto>().ReverseMap();
                CreateMap<CreateRequestTagDto, Tags>();
                CreateMap<UpdateRequestTagDto, Tags>();
            }
        }
    
}
