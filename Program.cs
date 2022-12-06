using ProjectManager.DAL.Data;
using Microsoft.EntityFrameworkCore;
using ProjectManager.BAL.Services;
using ProjectManager.BAL.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IProjectService,ProjectService>();//Registering my Services
builder.Services.AddScoped<ITaskService,TaskService>();

//Registering my DbContext
builder.Services.AddDbContext<ProjectManagerDbContext>(options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("NotesDbConnectionString")));

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
