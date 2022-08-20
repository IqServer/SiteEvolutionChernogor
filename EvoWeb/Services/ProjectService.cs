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

    public void Add(string title,
                    string description,
                    string advertLink,
                    string iconLink,
                    uint price)
    {
        Project newProject = new Project();
        newProject.Title = title;
        newProject.Description = description;
        newProject.AdvertLink = advertLink;
        newProject.IconLink = iconLink;
        newProject.Price = price;
        _data.Add(newProject);
        _data.SaveChanges();
        
    }

    public List<Project> GetAll()
    {
        return _data.Projects.ToList();
    }

    public void Remove(string title)
    {
        foreach (Project item in GetAll())
        {
            if (item.Title == title)
            {
                _data.Projects.Remove(item);
                _data.SaveChanges();
                break;
            }
        }
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
}