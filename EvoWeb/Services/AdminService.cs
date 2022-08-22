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

    public void DefaultAdmin()
    {
        Admin newAdmin = new Admin(); // создаем экземпляр
        newAdmin.Login = "root"; // заполняем поля
        newAdmin.Password = "root"; // тоже поле
        _data.Add(newAdmin); //добавляем в таблицу
        _data.SaveChanges(); //сохраняем изменеия
        _logger.Log(LogLevel.Warning, "Создан админ по умолчанию");
    }

    public List<Admin> GetAllAdmins()
    {
        _logger.Log(LogLevel.Information, "Вывод списка админов");
        return _data.Admins.ToList();
    }
    
    public void WipeAllAdmins()
    {
        foreach (var item in GetAllAdmins())
        {
            _data.Admins.Remove(item);
            _logger.Log(LogLevel.Warning, $"Удален админ {item}");
        }
        _data.SaveChanges();
    }

    public void RemoveAdmin(int id, string oldPass)
    {
        Admin? admin = _data.Admins.FirstOrDefault(x => x.Id == id);
        if (admin.Password == oldPass)
        {
            _data.Admins.Remove(admin);
            _logger.Log(LogLevel.Warning, $"Удален админ {admin}");
            _data.SaveChanges();
        }
        else
        {
            _logger.Log(LogLevel.Error, "Пароль неверен или не найден пользователь");
        }
        
    }

    public void AddAdmin(Admin admin)
    {
        _data.Admins.Add(admin);
        _data.SaveChanges();
    }

    public Admin? GetAdmin(int id)
    {
        return _data.Admins.FirstOrDefault(x => x.Id == id);
    }

    public void UpdatePass(int id,string oldPass, string newPass)
    {
        Admin? admin = _data.Admins.FirstOrDefault(x => x.Id == id);
        if (admin.Password == oldPass)
        {   
            admin.Password = newPass;
            _logger.Log(LogLevel.Information, $"Пароль {admin.Login} заменен");
        }
        else
        {
            _logger.Log(LogLevel.Error, $"Пароль неверен или не найден пользователь");
        }

        _data.Admins.Update(admin);
        _data.SaveChanges();
    }
}