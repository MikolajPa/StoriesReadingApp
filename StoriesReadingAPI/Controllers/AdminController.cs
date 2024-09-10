using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using StoriesReadingAPI.DTOs;
using StoriesReadingAPI.Models;
using StoriesReadingAPI.Repositories;
using StoriesReadingAPI.Services.Interfaces;
using StoriesReadingAPI.Services.ServiceModels;

//[Authorize]
[ApiController]
[Route("api/adminPanel")]
public class AdminController : ControllerBase
{
    private readonly ILogger<LanguageController> _logger;
    private readonly IAdminService _adminService;
    private readonly IMapper _mapper;

    public AdminController(IAdminService adminService, ILogger<LanguageController> logger, IMapper mapper)
    {
        _logger = logger;
        _adminService = adminService;
        _mapper = mapper;
    }

    [HttpPost("PostText")]
    public IActionResult PostText([FromBody] TextRequestDto textsRequest)
    {
        _adminService.PostText(_mapper.Map<TextAdminServiceModel>(textsRequest));
        return Ok();
    }

    [HttpGet("GetLanguageWithLanguageLevels")]
    public IActionResult GetLanguagesWithLevels()
    {
        return Ok(_mapper.Map<List<LanguageResponseDto>>(_adminService.GetLanguages()));
    }

    [HttpGet("GetLanguage")]
    public IActionResult GetLanguages()
    {
        return Ok(_mapper.Map<List<LanguageResponseDto>>(_adminService.GetLanguages()));
    }

    [HttpPost("PostLanguage")]
    public IActionResult PostLanguage([FromBody] LanguageRequestDto textsRequest)
    {
        _adminService.PostLanguage(_mapper.Map<Languages>(textsRequest));
        return Ok();
    }

    [HttpPost("PostLanguageLevel")]
    public IActionResult PostLanguageLevel([FromBody] LanguageLevelRequest languageLevelRequest)
    {
        _adminService.PostLanguageLevel(_mapper.Map<LanguageLevels>(languageLevelRequest));
        return Ok();
    }

    [HttpPost("PostLanguageLevels")]
    public IActionResult PostLanguageLevels(int languageId, [FromBody] List<LanguageLevelRequest> languageLevelsRequest)
    {
        try
        {
            _adminService.PostLanguageLevels(_mapper.Map<List<LanguageLevels>>(languageLevelsRequest), languageId);
        }
        catch(Exception ex) //Dodac handling customowych errorow, jezeli jest to Exception to wyrzuc typowe new Exception 500 i tyle, w przypadku customowych wysylaj z ich wiadomosciami. Te wiadomosci powinny byc typu const w 1 pliku. Kazdy z nowo dodanych errorow powinien dziedziczyc z klasy Exception
        {
            throw ex;
        }
        return Ok();
    }

    [HttpDelete("DeleteLanguageLevel/{languageLevelId}")]
    public IActionResult DeleteLanguageLevel(int languageLevelId)
    {
        try
        {
            _adminService.DeleteLanguageLevel(languageLevelId);
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        return NoContent();
    }

    [HttpDelete("DeleteLanguage/{languageId}")]
    public IActionResult DeleteLanguage(int languageId)
    {
        try
        {
            _adminService.DeleteLanguage(languageId);
        }
        catch(ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        return NoContent();
    }

    [HttpGet("GetLanguageLevel/{languageId}")]
    public IActionResult GetLanguageLevels(int languageId)
    {
        return Ok(_mapper.Map<List<LanguageLevelResponse>>(_adminService.GetLanguageLevels(languageId)));
    }
}