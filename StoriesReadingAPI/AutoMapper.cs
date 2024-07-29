
using AutoMapper;
using StoriesReadingAPI.DTOs;
using StoriesReadingAPI.Models;
using StoriesReadingAPI.Services.ServiceModels;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<LanguageLevels, LanguageLevelResponse>();
        CreateMap<LanguageLevelRequest, LanguageLevels>();
        CreateMap<Languages, LanguageResponseDto>();
        CreateMap<LanguageRequestDto, Languages>();
        CreateMap<Sentences, SentenceDto>();
        CreateMap<Texts, TextResponseDto>();
        CreateMap<TextRequestDto, Texts>();
        CreateMap<TextRequestDto, TextAdminServiceModel>();
    }
}