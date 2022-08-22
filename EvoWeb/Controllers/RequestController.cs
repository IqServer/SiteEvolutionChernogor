using EvoWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace EvoWeb.Controllers;

public class RequestController
{
    private ILogger<RequestController> _logger;
    private RequestService _service;

    public RequestController(ILogger<RequestController> logger, RequestService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet("GetAllRequests")]
    public List<Request> GetAllRequests()
    {
        return _service.GetAllRequests();
    }

    [HttpGet("GetRequest")]
    public Request GetRequest(int id)
    {
        return _service.GetRequest(id);
    }

    [HttpPost("AddRequest")]
    public void AddRequest(Request newRequest)
    {
        _service.AddRequest(newRequest);
    }

    [HttpDelete("RemoveRequest")]
    public void RemoveRequest(int id)
    {
        _service.RemoveRequest(id);
    }
    
}