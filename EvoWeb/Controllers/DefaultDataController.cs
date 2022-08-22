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

    [HttpPost("DefaultAllData")]
    public void DefaultAllData()
    {
        _logger.Log(LogLevel.Warning, "Выполняется создание данных по умолчанию...");
        _projectService.DefaultProject();
        _workerService.Default();
        _requestService.DefaultRequest();
        _adminService.DefaultAdmin();
    }

    [HttpDelete("WipeAllData")]
    public void WipeAllData()
    {
        _logger.Log(LogLevel.Warning, "Выполняется очистка базы данных...");
        _adminService.WipeAllAdmins();
        _projectService.WipeAllProjects();
        _requestService.WipeAllRequests();
        _workerService.WipeAll();
    }
}