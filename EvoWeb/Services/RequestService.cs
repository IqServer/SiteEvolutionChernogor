namespace EvoWeb.Services;

public class RequestService
{
    private DataContext _data;
    private ILogger<RequestService> _logger;

    public RequestService(DataContext data, ILogger<RequestService> logger)
    {
        _data = data;
        _logger = logger;
    }

    public void DefaultRequest()
    {
        Request newRequest = new Request
        {
            Surname = "Белич",
            Name = "Дмитрий",
            FathersName = "Александрович",
            Email = "йцуке@rtyui.rtyui",
            Mobile = "88005553535",
            Description = "Описание",
            Title = "Штука",
            IsCustom = false,
            IsHistory = false
        };

        _data.Add(newRequest);
        _data.SaveChanges();
    }

    public void WipeAllRequests()
    {
        foreach (var item in GetAllRequests())
        {
            _data.Requests.Remove(item);
        }
        _data.SaveChanges();
    }
    
    public Request GetRequest(int id)
    {
        Request request = _data.Requests.FirstOrDefault(x => x.Id == id);
        _logger.Log(LogLevel.Information, $"Получена заявка {request.Title}");
        return request;
    }

    public List<Request> GetAllRequests()
    {
        _logger.Log(LogLevel.Information, "Получены все заявки");
        return _data.Requests.ToList();
    }

    public void AddRequest(Request request)
    {
        _data.Requests.Add(request);
        _data.SaveChanges();
        _logger.Log(LogLevel.Information, $"Записан запрос {request.Title}");
    }

    public void RemoveRequest(int id)
    {
        Request request = _data.Requests.FirstOrDefault(x => x.Id == id);
        _data.Requests.Remove(request);
        _data.SaveChanges();
    } 
}