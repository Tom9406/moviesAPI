﻿using AutoMapper;
using MoviesApi.Controllers;
using MoviesApi.Dto;
using MoviesApi.Entities;

namespace MoviesApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GenresDto, Genre>().ReverseMap();
            CreateMap<GenresCreationDto, Genre>();

            //Subjects
            CreateMap<subjectDTO, subject>().ReverseMap();
            CreateMap<subjectCreationDTO, subject>();

        }
    }
}