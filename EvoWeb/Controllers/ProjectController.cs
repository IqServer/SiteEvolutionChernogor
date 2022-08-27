using EvoWeb.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace EvoWeb.Controllers;

[ApiController]
[Route("/api/[controller]")]

public class ProjectController : ControllerBase
{
    private readonly ILogger<ProjectController> _logger;
    private readonly ProjectService _service;

    public ProjectController(ILogger<ProjectController> logger, ProjectService service)
    {
        _logger = logger;
        _service = service;
    }
    
    [HttpGet("GetAllProjects")]
    public List<Project> GetAllProjects()
    {
        return _service.GetAllProjects();
    }

    [HttpGet("GetProject")]
    public Project? GetProject(int id)
    {
        return _service.GetProject(id);
    }

    [HttpPost("AddProject")]
    public void AddProjects([FromBody]Project project)
    {
        _service.AddProjects(project);
    }

    [HttpDelete("RemoveProject")]
    public void RemoveProject(int id)
    {
        _service.RemoveProject(id);
    }

    [HttpOptions("SetProjetcInactive")]
    public void SetProjectInactive(int id)
    {
        _service.SetInactive(id);
    }

    [HttpOptions("SetProjectActve")]
    public void SetProjectActive(int id)
    {
        _service.SetActive(id);
    }

    [HttpPost("UpdateProject")]
    public void UpdateProject([FromBody]Project project)
    {
        _service.UpdateProject(project);
    }

    [HttpGet("GetAllActiveProjects")]
    public List<Project> GetAllActiveProjects()
    {
        return _service.GetAllActiveProjects();
    }
    
    
}