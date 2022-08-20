﻿namespace EvoWeb.Services;

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
        Worker newWorker = new Worker();
        newWorker.Surname = "Зубенко";
        newWorker.Name = "Михаил";
        newWorker.FathersName = "Петрович";
        newWorker.Post = "Мафиозник";
        newWorker.Description = "Lorem Ipsum";
        newWorker.PhotoLink = "about:blank";
        _data.Add(newWorker);
        _data.SaveChanges();
    }
}