using EvoWeb;
using EvoWeb.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
// логгер

builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console()
    .Enrich.WithProperty("Firma", "fir1")
    .WriteTo.Seq("http://localhost:5341")
);

builder.Services.AddCors(options => options.AddPolicy("AllowAll",
    builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    }));

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDbContext<DataContext>(opt =>
    {
        opt.UseNpgsql(configuration.GetConnectionString("Db"));
    }
);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<AdminService>();
builder.Services.AddScoped<ProjectService>();
builder.Services.AddScoped<RequestService>();
builder.Services.AddScoped<WorkerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
