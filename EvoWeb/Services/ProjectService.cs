namespace EvoWeb.Services;

public class ProjectService
{
    private DataContext _data;
    private ILogger<ProjectService> _logger;

    public ProjectService(DataContext data, ILogger<ProjectService> logger)
    {
        _data = data;
        _logger = logger;
    }

    public void AddProjects(Project newProject)
    {
        _data.Add(newProject);
        _data.SaveChanges();
        
    }

    public List<Project> GetAllProjects()
    {
        _logger.Log(LogLevel.Information, "Вызваны все проекты");
        return _data.Projects.Where(x => x.IsActive == true).ToList();
    }

    public Project? GetProject(int id)
    {
        Project? project = _data.Projects.FirstOrDefault(x => x.Id == id && x.IsActive == true);
        _logger.Log(LogLevel.Information, $"Найден проект {project.Title}");
        return project;
    }

    public void RemoveProject(int id)
    {
        Project? project = _data.Projects.FirstOrDefault(x => x.Id == id);
        _data.Projects.Remove(project);
        _logger.Log(LogLevel.Information, $"Удален проект {project.Title}");
        _data.SaveChanges();
    }

    public void SetInactive(int id)
    {
        Project project = _data.Projects.FirstOrDefault(x => x.Id == id);
        project.IsActive = false;
        _data.Projects.Update(project);
        _data.SaveChanges();
    }

    public void SetActive(int id)
    {
        Project project = _data.Projects.FirstOrDefault(x => x.Id == id);
        project.IsActive = true;
        _data.Projects.Update(project);
        _data.SaveChanges();
    }

    public void UpdateProject(Project project)
    {
        _data.Projects.Update(project);
        _data.SaveChanges();
    }
    public void DefaultProject()
    {
        Project newProject = new Project
        {
            Title = "Бакуган VR",
            Description = "Проект для VR",
            AdvertLink = "about:blank",
            IconLink = "about:blank",
            IsActive = true,
            Price = 100,
            DownLink = "about:blank"
        };
        _data.Add(newProject);
        _data.SaveChanges();
        _logger.Log(LogLevel.Information, "Создан проект по умолчанию");
    }

    public void WipeAllProjects()
    {
        _logger.Log(LogLevel.Information, "Удаление проектов...");
        foreach (var item in GetAllProjects())
        {
            _data.Projects.Remove(item);
            _logger.Log(LogLevel.Information, $"Удален проект {item.Title}");
        }
        _data.SaveChanges();
        _logger.Log(LogLevel.Information, "Проекты удалены");
    }
}