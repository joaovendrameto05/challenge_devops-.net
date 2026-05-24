var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

// Habilita o Swagger globalmente
app.UseSwagger(); 
app.UseSwaggerUI(options => 
{ 
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "celticsTech API v1");
    options.RoutePrefix = string.Empty; // Isso faz o Swagger abrir direto no http://ip:8080/
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();