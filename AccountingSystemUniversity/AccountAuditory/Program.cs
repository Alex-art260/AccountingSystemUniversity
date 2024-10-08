using AccountAuditory.Data;
//using AccountingSystemUniversity.Interfaces;
//using AccountingSystemUniversity.MappingProfiles;
//using AccountingSystemUniversity.Services;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.Extensions.Logging;
using AccountAuditory.Interfaces;
using AccountAuditory.Services;
using AccountingSystemUniversity.MappingProfiles;
using AccountAuditory.Data.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

builder.Services.AddScoped<IAuditoryService, AuditoryService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AuditoryProfile).Assembly);


builder.Logging.AddConsole(); // Вывод в консоль
builder.Logging.AddDebug(); // Вывод в отладочный вывод

builder.Services.Configure<RabbitMqConfiguration>(builder.Configuration.GetSection("RabbitMq"));
builder.Services.AddHostedService<RabbitMqConsumerService>();


var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseCors(options =>
    options.WithOrigins("http://localhost:4200")
           .AllowAnyMethod()
           .AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
