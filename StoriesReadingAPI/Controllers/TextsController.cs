using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using StoriesReadingAPI.DTOs;
using StoriesReadingAPI.Repositories;

[ApiController]
[Route("api/texts")]
public class TextsController : ControllerBase
{
    private readonly ILogger<LanguageController> _logger;
    private readonly ITextsRepository _repository;
    private readonly IMapper _mapper;

    public TextsController(ITextsRepository repository, ILogger<LanguageController> logger, IMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }


    [HttpGet("originalLanguage/{originalLanguageId}/translationLanguage/{translationLanguageId}/languageLevel/{languageLevelId}")]
    public IActionResult GetLanguageOrigin(int originalLanguageId, int translationLanguageId, int languageLevelId)
    {
        var texts = _repository.GetTextsTitles(originalLanguageId, translationLanguageId, languageLevelId);
        _logger.LogDebug($"Get method called, got {texts.Count()} results");
        List<TextRequestDto> textsDtos= _mapper.Map<List<TextRequestDto>>(texts);
        return Ok(textsDtos);
    }
}