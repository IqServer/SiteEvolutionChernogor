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

    [HttpGet]
    public Project? GetProjectById(int id)
    {
        return _service.GetProjectById(id);
    }

    [HttpPost("Add")]
    public void Add([FromBody]Project project)
    {
        _service.Add(project);
    }
    
}