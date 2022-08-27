using EvoWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace EvoWeb.Controllers;

[ApiController]
[Route("/api/[controller]")]

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
    public void UpdateWorker([FromBody]Worker worker)
    {
        _service.UpdateWorker(worker);
    }

    [HttpDelete("RemoveWorker")]
    public void Remove(int id)
    {
        _service.Remove(id);
    }

    [HttpOptions("SetInactiveWorker")]
    public void SetInactive(int id)
    {
        _service.SetInactive(id);
    }

    [HttpOptions("SetActiveWorker")]
    public void SetActive(int id)
    {
        _service.SetActive(id);
    }
}