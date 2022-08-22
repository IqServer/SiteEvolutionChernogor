using EvoWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace EvoWeb.Controllers;

public class AdminController
{
    private ILogger<AdminController> _logger;
    private DataContext _data;
    private AdminService _adminService;

    public AdminController(ILogger<AdminController>? logger, DataContext data, AdminService adminService)
    {
        _logger = logger;
        _data = data;
        _adminService = adminService;
    }

    [HttpGet("GetAllAdmins")]
    public List<Admin>? GetAllAdmins()
    {
        return _adminService.GetAllAdmins();
    }

    [HttpGet("GetAdmin")]
    public Admin GetItem(int id)
    {
        return _adminService.GetAdmin(id);
    }

    [HttpPost("AddAdmin")]
    public void AddAdmin(Admin admin)
    {
        _adminService.AddAdmin(admin);
    }

    [HttpPost("EditPass")]
    public void EditPass(int id, string oldPass, string newPass)
    {
        _adminService.EditPass(id, oldPass, newPass);
    }

    [HttpDelete("Remove")]
    public void Remove(int id, string oldPass)
    {
        _adminService.RemoveAdmin(id, oldPass);
    }
}