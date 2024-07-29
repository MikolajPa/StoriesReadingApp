﻿using AutoMapper;
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
        _adminService.DeleteLanguageLevel(languageLevelId);
        return NoContent();
    }

    [HttpDelete("DeleteLanguage/{languageId}")]
    public IActionResult PostText(int languageId)
    {
        _adminService.DeleteLanguageLevel(languageId);
        return Ok();
    }
}