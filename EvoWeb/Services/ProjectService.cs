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

    public void Add(Project newProject)
    {
        _data.Add(newProject);
        _data.SaveChanges();
        
    }

    public List<Project> GetAll()
    {
        return _data.Projects.ToList();
    }

    public Project? GetProjectById(int id)
    {
        return _data.Projects.FirstOrDefault(x => x.Id == id);
    }

    public void Remove(int id)
    {
        
        /* велосипед
        foreach (Project item in GetAll())
        {
            if (item.Title == title)
            {
                _data.Projects.Remove(item);
                _data.SaveChanges();
                break;
            }
        }
        */
        //_data.Projects.FirstOrDefault(x => x.id == id).Remove();
    }
    

    public void Default()
    {
        Project newProject = new Project();
        newProject.Title = "Lorem Ipsum";
        newProject.Description = "Lorem Ipsum";
        newProject.AdvertLink = "about:blank";
        newProject.IconLink = "about:blank";
        newProject.Price = 0;
        _data.Add(newProject);
        _data.SaveChanges();
    }

    public void WipeAll()
    {
        foreach (var item in GetAll())
        {
            _data.Projects.Remove(item);
        }
        _data.SaveChanges();
    }
}