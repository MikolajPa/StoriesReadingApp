
using AutoMapper;
using StoriesReadingAPI.DTOs;
using StoriesReadingAPI.Models;
using StoriesReadingAPI.Services.ServiceModels;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<LanguageLevels, LanguageLevelDto>();
        CreateMap<Languages, LanguageDto>();
        CreateMap<Sentences, SentenceDto>();
        CreateMap<Texts, TextResponseDto>();
        CreateMap<TextRequestDto, Texts>();
        CreateMap<TextRequestDto, TextAdminServiceModel>();
    }
}