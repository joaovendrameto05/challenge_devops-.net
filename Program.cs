using celticsTech.Data;
using celticsTech.Middlewares;
using celticsTech.Repositories;
using celticsTech.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração simples para Banco em Memória
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("CelticsDb"));

builder.Services.AddControllers();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<IVeterinarianRepository, VeterinarianRepository>();
builder.Services.AddScoped<IConsultationRepository, ConsultationRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<PetService>();
builder.Services.AddScoped<VeterinarianService>();
builder.Services.AddScoped<ConsultationService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseSwagger();
app.UseSwaggerUI(options => { options.RoutePrefix = string.Empty; });

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();