using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using StoriesReadingAPI.DTOs;
using StoriesReadingAPI.Repositories;

[ApiController]
[Route("api/sentences")]
public class SentencesController : ControllerBase
{
    private readonly ILogger<LanguageController> _logger;
    private readonly ISentencesRepository _repository;
    private readonly IMapper _mapper;

    public SentencesController(ISentencesRepository repository, ILogger<LanguageController> logger, IMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet("text/{textId}")]
    public IActionResult GetSentences(int textId)
    {
        var sentences = _repository.GetSentences(textId);
        _logger.LogDebug($"Get method called, got {sentences.Count()} results");
        List<SentenceDto> sentenceDto= _mapper.Map<List<SentenceDto>>(sentences);
        return Ok(sentenceDto);
    }

}