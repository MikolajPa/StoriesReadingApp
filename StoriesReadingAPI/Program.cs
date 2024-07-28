using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using StoriesReadingAPI.Models;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using StoriesReadingAPI.Repositories;
using StoriesReadingAPI.Services;
using StoriesReadingAPI.Services.Interfaces;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//This section below is for connection string 
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SampleDBContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();
builder.Services.AddScoped<ILanguageLevelsRepository, LanguageLevelRepository>();
builder.Services.AddScoped<ITextsRepository, TextsRepository>();
builder.Services.AddScoped<ISentencesRepository, SentencesRepository>();
builder.Services.AddScoped<ILanguageService, LanguageService>();
builder.Services.AddScoped<ILanguageLevelService, LanguageLevelService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<ILanguageService, LanguageService>();
builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


