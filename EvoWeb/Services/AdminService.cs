namespace EvoWeb.Services;

public class AdminService
{
    private DataContext _data;
    private ILogger<AdminService> _logger;

    public AdminService(DataContext data, ILogger<AdminService> logger)
    {
        _data = data;
        _logger = logger;
    }

    public void Default()
    {
        Admin newAdmin = new Admin(); // создаем экземпляр
        newAdmin.Login = "root"; // заполняем поля
        newAdmin.Password = "root"; // тоже поле
        _data.Add(newAdmin); //добавляем в таблицу
        _data.SaveChanges(); //сохраняем изменеия
    }
}