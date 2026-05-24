using celticsTech.Data;
using celticsTech.Middlewares;
using celticsTech.Repositories;
using celticsTech.Services;
using Microsoft.EntityFrameworkCore; // ISSO É OBRIGATÓRIO PARA O UseInMemoryDatabase

var builder = WebApplication.CreateBuilder(args);

// Configuração corrigida
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("CelticsDb"));

builder.Services.AddControllers();
// ... resto do seu código