using application.Config;
using application.Repositories.Interfaces;
using application.Repositories.Queries;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

#region appsettings
AppSettings.Init();
#endregion

#region Dependency injection
builder.Services.AddScoped<IRepoCategory, QCategory>();
builder.Services.AddScoped<IRepoHomework, QHomework>();
#endregion

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowOnlyDefaults");
app.MapControllers();

app.Run();