using Microsoft.AspNetCore.Mvc;
using EvoWeb.Services;

namespace EvoWeb.Controllers;

public class EmailController : Controller
{
    private DataContext _data;

    public EmailController(DataContext data)
    {
        _data = data;
    }

    [HttpPost("SendEmail")]
    public async Task<string> SendMessage(int id)
    {
        EmailService emailService = new EmailService();
        Request request = _data.Requests.FirstOrDefault(x => x.Id == id);
        await emailService.SendEmailAsync(request.Email, "Тема письма", "Тест письма: тест!");
        return "Отправил";
    }

    void dfghj()
    {
        
    }
}