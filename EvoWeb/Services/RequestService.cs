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

    public void Default()
    {
        Request newRequest = new Request();
        newRequest.Surname = "Белич";
        newRequest.Name = "Дмитрий";
        newRequest.FathersName = "Александрович";
        newRequest.Email = "йцуке@rtyui.rtyui";
        newRequest.Mobile = "88005553535";
        newRequest.Description = "Lorem Ipsum";
        newRequest.Title = "Пуп";
        newRequest.IsCustom = false;
        
        _data.Add(newRequest);
        _data.SaveChanges();
    }

    public List<Request> GetAll()
    {
        return _data.Requests.ToList();
    }

    public void WipeAll()
    {
        foreach (var item in GetAll())
        {
            _data.Requests.Remove(item);
        }
        _data.SaveChanges();
    }
}