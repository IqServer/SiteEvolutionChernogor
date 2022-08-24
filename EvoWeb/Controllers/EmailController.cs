using Microsoft.AspNetCore.Mvc;
using EvoWeb.Services;
using Microsoft.EntityFrameworkCore;

namespace EvoWeb.Controllers;

[ApiController]
[Route("/api/[controller]/[action]")]

public class EmailController : Controller
{
    private DataContext _data;
    private EmailService _service;

    public EmailController(DataContext data, EmailService service)
    {
        _data = data;
        _service = service;
    }

    [HttpGet("SendEmailTest")]
    public async Task SendMessage(int id)
    {
        Request request = _data.Requests.FirstOrDefault(x => x.Id == id);
        await _service.SendEmailAsync(request.Email, "Тема письма", "Тест письма: тест!");
    }

    [HttpGet("SendEmailRegistration")]
    public async Task SendEmailRegistration(int id)
    {
        Request request = _data.Requests.FirstOrDefault(x => x.Id == id);
        await _service.SendEmailAsync(request.Email,
            "Регистрация на приобретение",
            $"Здравствуйте, {request.Surname} {request.Name}. Вы зарегистрировались на приобретение {request.Title}");
    }

    [HttpGet("SendEmailAccept")]
    public async Task SendEmailAccept(int id)
    {
        Request request = _data.Requests.FirstOrDefault(x => x.Id == id);
        Project project = _data.Projects.FirstOrDefault(x => x.Title == request.Title);
        await _service.SendEmailAsync(request.Email,
            "Заявка одобрена",
            $"Здравствуйте, {request.Surname} {request.Name}. Ваша заявка на приобретение {request.Title} одобрена." +
            $"Ваша ссылка на скачивание: {project.DownLink}");
        request.IsActive = false;
        _data.Requests.Update(request);
        await _data.SaveChangesAsync();
    }
    
    [HttpGet("SendEmailDecline")]
    public async Task SendEmailDecline(int id)
    {
        Request request = _data.Requests.FirstOrDefault(x => x.Id == id);
        await _service.SendEmailAsync(request.Email,
            "Заявка одобрена",
            $"Здравствуйте, {request.Surname} {request.Name}. Ваша заявка на приобретение {request.Title} отклонена");
        request.IsActive = false;
        _data.Requests.Update(request);
        await _data.SaveChangesAsync();
    }
}