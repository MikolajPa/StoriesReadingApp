using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using StoriesReadingAPI.DTOs;
using StoriesReadingAPI.Repositories;

[ApiController]
[Route("api/languageLevel")]
public class LanguagelevelController : ControllerBase
{
    private readonly ILogger<LanguageController> _logger;
    private readonly ILanguageLevelsRepository _repository;
    private readonly IMapper _mapper;

    public LanguagelevelController(ILanguageLevelsRepository repository, ILogger<LanguageController> logger, IMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }


    [HttpGet]
    [HttpGet("{languageLevelId}")]
    public IActionResult GetPost(int languageLevelId)
    {
        var languageLevels = _repository.GetLanguageLevels(languageLevelId);
        _logger.LogDebug($"Get method called, got {languageLevels.Count()} results");
        List<LanguageLevelDto> languageLevelsDto= _mapper.Map<List<LanguageLevelDto>>(languageLevels);
        return Ok(languageLevelsDto);
    }

}