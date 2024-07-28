using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using StoriesReadingAPI.DTOs;
using StoriesReadingAPI.Repositories;
using StoriesReadingAPI.Services.Interfaces;

[ApiController]
[Route("api/language")]
public class LanguageController : ControllerBase
{
    private readonly ILogger<LanguageController> _logger;
    private readonly ILanguageService _languageService;
    private readonly IMapper _mapper;

    public LanguageController(ILanguageService languageService, ILogger<LanguageController> logger, IMapper mapper)
    {
        _logger = logger;
        _languageService = languageService;
        _mapper = mapper;
    }


    [HttpGet("languagesOrigin")]
    public IActionResult GetLanguageOrigin()
    {
        var languages = _languageService.GetLanguageOrigin();
        _logger.LogDebug($"Get method called, got {languages.Count()} results");
        List<LanguageDto> languageDtos= _mapper.Map<List<LanguageDto>>(languages);
        return Ok(languageDtos);
    }

    [HttpGet("languageTranslations/{originLanguageId}")]
    public IActionResult GetLanguageTranslation(int originLanguageId)
    {
        var languages = _languageService.GetLanguageTranslation(originLanguageId);
        _logger.LogDebug($"Get method called, got {languages.Count()} results");
        List<LanguageDto> languageDtos = _mapper.Map<List<LanguageDto>>(languages);
        return Ok(languageDtos);
    }
}