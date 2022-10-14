using APIFilmes.Data;
using APIFilmes.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Adiciona a string de conexão "ConnectionMySQL" na variável connectionStringMySQL
var connectionStringMySQL = builder.Configuration.GetConnectionString("ConnectionMySQL");
//Define que o tipo de Banco de Dados será o MYSQL na versão 8.0.30
builder.Services.AddDbContext<AppDbContext>(opts => opts.UseLazyLoadingProxies().UseMySql(connectionStringMySQL, ServerVersion.Parse("8.0.30")));

//Adiciona a extenção Auto Mapper na API
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Inicializa as classes Service na API
builder.Services.AddScoped<FilmeService , FilmeService>();
builder.Services.AddScoped<CinemaService, CinemaService>();
builder.Services.AddScoped<EnderecoService, EnderecoService>();
builder.Services.AddScoped<GerenteService, GerenteService>();
builder.Services.AddScoped<SessaoService, SessaoService>();

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
