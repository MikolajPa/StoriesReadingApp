using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using StoriesReadingAPI.DTOs;
using StoriesReadingAPI.Repositories;
using StoriesReadingAPI.Services.Interfaces;
using StoriesReadingAPI.Services.ServiceModels;

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
    public IActionResult PostText([FromBody]TextRequestDto textsRequest)
    {
        _adminService.PostText(_mapper.Map<TextAdminServiceModel>(textsRequest));
        return Ok();
    }
}