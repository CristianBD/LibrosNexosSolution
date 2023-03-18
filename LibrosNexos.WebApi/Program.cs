using AutoMapper;
using LibrosNexos.Infrastucture.Extensions;
using LibrosNexos.Infrastucture.Mapping;
using LibrosNexos.Persistence.Context;
using LibrosNexos.Persistence.Context.IContext;
using LibrosNexos.Service.Contract;
using LibrosNexos.Service.Implementation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Connection to DataBase Zona Virtual
builder.Services.AddDbContext<LibrosNexosContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnection")));
builder.Services.AddScoped<ILibrosNexosContext, LibrosNexosContext>();

//Add Repository Manager
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

//Add AutoMapper
builder.Services.AddAutoMapper(typeof(ConfigureServiceContainer).Assembly);
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new TBL_GENEROS_GenerosViewModel());
});

//Cors
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors("corsapp");
app.MapControllers();

app.Run();
