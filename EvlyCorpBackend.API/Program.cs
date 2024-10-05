using EvlyCorpBackend.CORE.INTERFACES;
using EvlyCorpBackend.CORE.SERVICES;
using EvlyCorpBackend.INFRASTRUCTURE.Data;
using EvlyCorpBackend.INFRASTRUCTURE.REPOSITORIES;
using EvlyCorpBackend.INFRASTRUCTURE.SHARED;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var _config = builder.Configuration;
var _connectionString = _config.GetConnectionString("DevConnection");

builder.Services.AddDbContext<ResiduContext>(options =>
{
    options.UseNpgsql(_connectionString);

});

builder.Services.AddTransient<ImunicipalitiesService, MunicipalitiesService>();
builder.Services.AddTransient<ImunicipalitiesRepository, MunicipalitiesRepository>();
builder.Services.AddTransient<IProvincesService, ProvincesService>();
builder.Services.AddTransient<IProvincesRepository, ProvincesRepository>();
builder.Services.AddTransient<IDepartmentsService, DepartmentsService>();
builder.Services.AddTransient<IDepartmentsRepository, DepartmentsRepository>();
builder.Services.AddTransient<IDistrictsService, DistrictsService>();
builder.Services.AddTransient<IDistrictsRepository, DistrictsRepository>();
builder.Services.AddTransient<IWastesService, WastesService>();
builder.Services.AddTransient<IWastesRepository, WastesRepository>();
builder.Services.AddTransient<IManagementCompanyService, ManagementCompanyService>();
builder.Services.AddTransient<IManagementCompanyRepository, ManagementCompanyRepository>();
builder.Services.AddTransient<IUsersService, UsersService>();
builder.Services.AddTransient<IUsersRepository, UsersRepository>();
builder.Services.AddTransient<IJWTService, JWTService>();




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

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
