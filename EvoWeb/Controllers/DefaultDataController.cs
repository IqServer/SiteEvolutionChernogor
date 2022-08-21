using Microsoft.AspNetCore.Mvc;
using EvoWeb.Services;

namespace EvoWeb.Controllers;

public class DefaultDataController : ControllerBase
{
    private ILogger<DefaultDataController> _logger;
    private ProjectService _projectService;
    private AdminService _adminService;
    private RequestService _requestService;
    private WorkerService _workerService;
    
    
    public DefaultDataController(ILogger<DefaultDataController> logger,
        ProjectService projectService,
        AdminService adminService,
        RequestService requestService,
        WorkerService workerService)
    {
        _logger = logger;
        _projectService = projectService;
        _adminService = adminService;
        _requestService = requestService;
        _workerService = workerService;
    }

    [HttpPost("DefaultAll")]
    public void DefaultAll()
    {
        _logger.Log(LogLevel.Warning, "Выполняется создание данных по умолчанию");
        _projectService.Default();
        _workerService.Default();
        _requestService.Default();
        _adminService.Default();
    }

    [HttpDelete("WipeAll")]
    public void WipeAll()
    {
        _logger.Log(LogLevel.Warning, "Выполняется очистка базы данных");
        _adminService.WipeAll();
        _projectService.WipeAll();
        _requestService.WipeAll();
        _workerService.WipeAll();
    }
}