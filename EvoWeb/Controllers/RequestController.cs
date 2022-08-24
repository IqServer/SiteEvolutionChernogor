using EvoWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace EvoWeb.Controllers;

[ApiController]
[Route("/api/[controller]/[action]")]

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
    public void AddRequest([FromBody]Request newRequest)
    {
        _service.AddRequest(newRequest);
    }

    [HttpDelete("RemoveRequest")]
    public void RemoveRequest(int id)
    {
        _service.RemoveRequest(id);
    }

    [HttpGet("GetAllActiveRequest")]
    public void GetAllActiveRequets()
    {
        _service.GetAllActiveRequests();
    }

    [HttpOptions("SetInactive")]
    public void SetInactive(int id)
    {
        _service.SetInactive(id);
    }

    [HttpOptions("SetActive")]
    public void SetActive(int id)
    {
        _service.SetActive(id);
    }
    
}