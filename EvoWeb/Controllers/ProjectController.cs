using EvoWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace EvoWeb.Controllers;

public class ProjectController : ControllerBase
{
    private readonly DataContext _context;
    private readonly ILogger<ProjectController> _logger;
    private readonly ProjectService _service;

    public ProjectController(DataContext context, ILogger<ProjectController> logger, ProjectService service)
    {
        _logger = logger;
        _context = context;
        _service = service;
    }
    
    [HttpGet("Get All")]
    public List<Project> GetAll()
    {
        return _service.GetAll();
    }

    [HttpPost("Add")]
    public void Add(string title,
        string description,
        string advertLink,
        string iconLink,
        uint price)
    {
        _service.Add(title, description, advertLink, iconLink, price);
    }

    [HttpDelete("Remove")]
    public void Remove(string title)
    {
        _service.Remove(title);
    }
}