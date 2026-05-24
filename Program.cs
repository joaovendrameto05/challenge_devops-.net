using celticsTech.Data;
using celticsTech.Middlewares;
using celticsTech.Repositories;
using celticsTech.Services;
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("CelticsDb"))
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("CelticsDb"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseSwagger();
app.UseSwaggerUI(options => { options.RoutePrefix = string.Empty; });

app.MapControllers();
app.Run();