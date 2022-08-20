using Microsoft.AspNetCore.Mvc;
using EvoWeb.Services;

namespace EvoWeb.Controllers;

public class DefaultDataController : ControllerBase 
{
    private DataContext _dataContext;
    private ProjectService _projectService;
    private AdminService _adminService;
    private RequestService _requestService;
    private WorkerService _workerService;
    
    
    public DefaultDataController(DataContext dataContext,
        ProjectService projectService,
        AdminService adminService,
        RequestService requestService,
        WorkerService workerService)
    {
        _projectService = projectService;
        _dataContext = dataContext;
        _adminService = adminService;
        _requestService = requestService;
        _workerService = workerService;
    }

    [HttpPost("DefaultAll")]
    public void DefaultAll()
    {
        _projectService.Default();
        _workerService.Default();
        _requestService.Default();
        //_adminService.Default();
    }
}