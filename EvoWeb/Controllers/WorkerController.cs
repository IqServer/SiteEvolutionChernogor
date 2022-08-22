using EvoWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace EvoWeb.Controllers;

public class WorkerController
{
    private WorkerService _service;
    private ILogger<WorkerService> _logger;

    public WorkerController(WorkerService service, ILogger<WorkerService> logger)
    {
        _service = service;
        _logger = logger;
    }

    /*
    [HttpGet("GetWorker")]
    public Worker GetWorker(int id)
    {
        
    }
    */
}