using Microsoft.EntityFrameworkCore;
using api.Data;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Início conexão com o banco de dados   
string stringDeConexao1 = builder.Configuration.GetConnectionString("conexaoMySQL1");
string stringDeConexao2 = builder.Configuration.GetConnectionString("conexaoMySQL2");

builder.Services.AddDbContext<DataContext>(opt => opt.UseMySql(stringDeConexao1, ServerVersion.AutoDetect(stringDeConexao1)));
builder.Services.AddDbContext<DataContext>(opt => opt.UseMySql(stringDeConexao2, ServerVersion.AutoDetect(stringDeConexao2)));
// Término da conexão com o banco de dados
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new() { Title = "TodoApi", Version = "v1" });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //app.UseSwagger();
    //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoApi v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();