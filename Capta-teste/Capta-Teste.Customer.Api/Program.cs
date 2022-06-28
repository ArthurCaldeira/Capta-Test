using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Capta_Teste.Customer.Api.Config;
using Capta_Teste.Customer.Api.Model.Context;
using Capta_Teste.Customer.Api.Repository;
using Capta_Teste.Customer.Api.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

// Set connectionstring
var connetion = builder.Configuration["SQLServerConnection:SQLServerConnectionString"];
builder.Services.AddDbContext<SqlServerContext>(options => options.UseSqlServer(connetion));

// Add Automapper
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerStatusRepository, CustomerStatusRepository>();
builder.Services.AddScoped<ICustomerTypeRepository, CustomerTypeRepository>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
