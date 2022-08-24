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
            IsActive = false
        };
        _logger.Log(LogLevel.Information, "Создан дефолтный работник");
        _data.Add(newWorker);
        _data.SaveChanges();
    }

    public List<Worker> GetAll()
    {
        _logger.Log(LogLevel.Information, "Выданы все работники");
        return _data.Workers.ToList();
    }
    
    public List<Worker> GetAllActive()
    {
        _logger.Log(LogLevel.Information, "Выданы все активные работники");
        return _data.Workers.Where(x => x.IsActive == true).ToList();
    }

    public void WipeAll()
    {
        _logger.Log(LogLevel.Information ,"Удаление работников...");
        foreach (var item in GetAll())
        {
            _data.Workers.Remove(item);
            _logger.Log(LogLevel.Information, $"Удален работник {item.Surname} {item.Name}");
        }
        _data.SaveChanges();
    }

    public Worker GetWorker(int id)
    {
        Worker worker = _data.Workers.FirstOrDefault(x => x.Id == id);
        _logger.Log(LogLevel.Information, $"Удален работник {worker.Surname} {worker.Name}");
        return worker;
    }

    public void AddWorker(Worker newWorker)
    {
        _logger.Log(LogLevel.Information, $"Добавлен работник {newWorker.Surname} {newWorker.Name}");
        _data.Workers.Add(newWorker);
        _data.SaveChanges();
    }

    public void UpdateWorker(Worker worker)
    {
        _logger.Log(LogLevel.Information, $"Обновлен работник {worker.Surname} {worker.Name}");
        _data.Workers.Update(worker);
        _data.SaveChanges();
    }

    public void Remove(int id)
    {
        Worker? worker = _data.Workers.FirstOrDefault(x => x.Id == id);
        _logger.Log(LogLevel.Information, $"Удален работник {worker.Name} {worker.Surname}");
        _data.Remove(worker);
        _data.SaveChanges();
    }
    
    public void SetInactive(int id)
    {
        Worker worker = _data.Workers.FirstOrDefault(x => x.Id == id);
        _logger.Log(LogLevel.Information,$"работник {worker.Name} {worker.Surname} неактивен");
        worker.IsActive = false;
        _data.Update(worker);
        _data.SaveChanges();
    }
    
    public void SetActive(int id)
    {
        Worker worker = _data.Workers.FirstOrDefault(x => x.Id == id);
        _logger.Log(LogLevel.Information,$"работник {worker.Name} {worker.Surname} активен");
        worker.IsActive = true;
        _data.Update(worker);
        _data.SaveChanges();
    }
    
}

