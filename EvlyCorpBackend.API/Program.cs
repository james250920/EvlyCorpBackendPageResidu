using EvlyCorpBackend.CORE.INTERFACES;
using EvlyCorpBackend.CORE.SERVICES;
using EvlyCorpBackend.CORE.SETTINGS;
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

// Configuraci�n de JWTSettings desde el archivo appsettings.json
builder.Services.Configure<JWTSettings>(_config.GetSection("JWTSettings"));

builder.Services.AddTransient<ImunicipalitiesService, MunicipalitiesService>();
builder.Services.AddTransient<IMunicipalitiesRepository, MunicipalitiesRepository>();
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
builder.Services.AddTransient<ICondominiumsService, CondominiumsService>();
builder.Services.AddTransient<ICondominiumsRepository, CondominiumsRepository>();
builder.Services.AddTransient<ICondominiumWastesService, CondominiumWastesService>();
builder.Services.AddTransient<ICondominiumWastesRepository, CondominiumWastesRepository>();
builder.Services.AddTransient<IOrdersService, OrdersService>();
builder.Services.AddTransient<IOrdersRepository, OrdersRepository>();

// Inyecci�n del servicio JWT
builder.Services.AddTransient<IJWTService, JWTService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("CorsPolicy");
app.MapControllers();
app.Run();
