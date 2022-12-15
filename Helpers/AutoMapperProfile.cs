using AutoMapper;
using MoviesApi.Controllers;
using MoviesApi.Dto;
using MoviesApi.Entities;
using System.Runtime.CompilerServices;

namespace MoviesApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GenresDto, Genre>().ReverseMap();
            CreateMap<GenresCreationDto, Genre>();

            //EXAM
            CreateMap<examDTO, exam>().ReverseMap();
            CreateMap<examCreationDTO, exam>(); //.ForMember(c =>  c.intents_number , option => option.Ignore()).ForMember(c => c.name, option => option.Ignore());

            //USER
            CreateMap<UserDTO, user>().ReverseMap();
            CreateMap<UserCreationDTO, user>();

            //LOGIN
            CreateMap<LoginDTO, login>().ReverseMap();
            CreateMap<LoginCreationDTO, login>();

            //SCORE
            //LOGIN
            CreateMap<ScoreDTO, Score>().ReverseMap();
            CreateMap<ScoreCreationDTO, Score>();


        }
    }
}
