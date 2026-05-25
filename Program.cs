using celticsTech.Data;
using celticsTech.Repositories;
using celticsTech.Services;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection") 
                       ?? builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(connectionString));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<IVeterinarianRepository, VeterinarianRepository>();
builder.Services.AddScoped<IConsultationRepository, ConsultationRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<PetService>();
builder.Services.AddScoped<VeterinarianService>();
builder.Services.AddScoped<ConsultationService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// TRUQUE DE MESTRE: Tenta criar as tabelas, se já existirem (Volume Persistente), ele ignora o erro e segue em frente!
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    try 
    {
        db.Database.EnsureCreated();
    }
    catch (Exception)
    {
        // Se cair aqui, é porque a tabela já existe no Volume (ORA-00955).
        // A persistência funcionou! Apenas ignoramos o erro de criação e seguimos.
    }
}

app.UseSwagger();
app.UseSwaggerUI(options => 
{ 
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "celticsTech API v1");
    options.RoutePrefix = string.Empty; 
});

app.MapControllers();
app.Run();