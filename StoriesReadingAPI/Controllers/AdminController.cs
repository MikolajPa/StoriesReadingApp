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

    [HttpGet("GetLanguageLevel/{languageId}")]
    public IActionResult GetLanguageLevels(int languageId)
    {
        return Ok(_mapper.Map<List<LanguageLevelResponse>>(_adminService.GetLanguageLevels(languageId)));
    }

    [HttpPost("PostLanguageLevel")]
    public IActionResult PostLanguageLevel([FromBody] LanguageLevelRequest textsRequest)
    {
        _adminService.PostLanguageLevel(_mapper.Map<LanguageLevels>(textsRequest));
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
}