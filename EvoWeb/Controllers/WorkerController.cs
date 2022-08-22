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

    
    [HttpGet("GetAllWorkers")]
    public List<Worker> GetAllWorkers()
    {
        return _service.GetAll();
    }

    [HttpGet("GetWorker")]
    public Worker GetWorker(int id)
    {
        return _service.GetWorker(id);
    }

    [HttpPost("AddWorker")]
    public void AddWorker([FromBody]Worker newWorker)
    {
        _service.AddWorker(newWorker);
    }

    [HttpPost("UpdateWorker")]
    public void UpdateWorker(int id, string description)
    {
        _service.UpdateWorker(id, description);
    }

    [HttpDelete("RemoveWorker")]
    public void Remove(int id)
    {
        _service.Remove(id);
    }
}