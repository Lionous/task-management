using application.Config;
using application.Repositories.Interfaces;
using application.Repositories.Queries;
using Microsoft.OpenApi.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

#region appsettings
AppSettings.Init();
#endregion

#region Dependency injection
builder.Services.AddScoped<IRepoCategory, QCategory>();
builder.Services.AddScoped<IRepoHomework, QHomework>();
builder.Services.AddScoped<IRepoReport, QReport>();
#endregion

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddOpenApi();
#region Swagger UI
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Gestión de Tareas.",
        Description = "Esta API realiza un crud básico de la gestion de tareas.",
        TermsOfService = new Uri("https://github.com/Lionous/task-management"),
        Contact = new OpenApiContact
        {
            Name = "Collaborators",
            Url = new Uri("https://github.com/Lionous"),
        },
        License = new OpenApiLicense
        {
            Name = "Licencse",
            Url = new Uri("https://github.com/Lionous/task-management#")
        }
    });
});
#endregion

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger(options => { options.SerializeAsV2 = true; });
    app.UseSwaggerUI(options => { options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"); });
}

app.UseHttpsRedirection();
app.UseCors("AllowOnlyDefaults");
app.MapControllers();

app.Run();