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
            IsActive = true
        };
        _logger.Log(LogLevel.Information, $"Создан дефолтный реквест");
        _data.Add(newRequest);
        _data.SaveChanges();
    }

    public void WipeAllRequests()
    {
        _logger.Log(LogLevel.Warning, "Удаление реквестов...");
        foreach (var item in GetAllRequests())
        {
            _data.Requests.Remove(item);
            _logger.Log(LogLevel.Information, $"Удален реквест {item.Title}");
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
        _logger.Log(LogLevel.Information, $"Создан реквест {request.Title}");
    }

    public void RemoveRequest(int id)
    {
        Request request = _data.Requests.FirstOrDefault(x => x.Id == id);
        _data.Requests.Remove(request);
        _logger.Log(LogLevel.Information, $"Удален реквест {request.Title}");
        _data.SaveChanges();
    }
    
    public List<Request> GetAllActiveRequests()
    {
        _logger.Log(LogLevel.Information, "Вызваны все активные заявки");
        return _data.Requests.Where(x => x.IsActive == true).ToList();
    }

    public void SetInactive(int id)
    {
        Request request = _data.Requests.FirstOrDefault(x => x.Id == id);
        _logger.Log(LogLevel.Information,$"реквест {request.Title} не активен");
        request.IsActive = false;
        _data.Update(request);
        _data.SaveChanges();
    }
    
    public void SetActive(int id)
    {
        Request request = _data.Requests.FirstOrDefault(x => x.Id == id);
        _logger.Log(LogLevel.Information,$"реквест {request.Title} активен");
        request.IsActive = true;
        _data.Update(request);
        _data.SaveChanges();
    }
}