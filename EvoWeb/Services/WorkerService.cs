using Microsoft.EntityFrameworkCore.Query.Internal;

namespace EvoWeb.Services;

public class WorkerService
{
    private DataContext _data;
    private ILogger<WorkerService> _logger;

    public WorkerService(DataContext data, ILogger<WorkerService> logger)
    {
        _data = data;
        _logger = logger;
    }

    public void Default()
    {
        Worker newWorker = new Worker
        {
            Surname = "Зубенко",
            Name = "Михаил",
            FathersName = "Петрович",
            Post = "Мафиозник",
            Description = "Lorem Ipsum",
            PhotoLink = "about:blank",
            IsHistory = false
        };
        _data.Add(newWorker);
        _data.SaveChanges();
    }

    public List<Worker> GetAll()
    {
        return _data.Workers.ToList();
    }

    public void WipeAll()
    {
        foreach (var item in GetAll())
        {
            _data.Workers.Remove(item);
        }
        _data.SaveChanges();
    }

    public Worker GetWorker(int id)
    {
        return _data.Workers.FirstOrDefault(x => x.Id == id);
    }

    public void AddWorker(Worker newWorker)
    {
        _data.Workers.Add(newWorker);
        _data.SaveChanges();
    }

    public void UpdateWorker(Worker worker)
    {
        _data.Workers.Update(worker);
        _data.SaveChanges();
    }

    public void Remove(int id)
    {
        Worker? worker = _data.Workers.FirstOrDefault(x => x.Id == id);
        _data.Remove(worker);
        _data.SaveChanges();
    }
}

