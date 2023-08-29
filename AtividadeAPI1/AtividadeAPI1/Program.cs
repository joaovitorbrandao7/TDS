using AtividadeAPI1.API.Model;
using AtividadeAPI1.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>();

var tasks = new List<AtividadeAPI1.API.Model.TaskModel>
{

};

builder.Services.AddSingleton(tasks);
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "AtividadeAPI1.API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();
}

app.MapGet("/atividadeAPI1", () =>
{
    var taskService = app.Services.GetRequiredService<List<AtividadeAPI1.API.Model.TaskModel>>();
    return Results.Ok(taskService);
});

app.MapGet("/atividadeAPI1/{id}", (int id, HttpRequest request) =>
{
    var taskService = app.Services.GetRequiredService<List<AtividadeAPI1.API.Model.TaskModel>>();
    var task = taskService.FirstOrDefault(t => t.Id == id);
    if (task == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(task);
});

app.MapPost("/atividadeAPI1", (AtividadeAPI1.API.Model.TaskModel TaskModel) =>
{
    var taskService = app.Services.GetRequiredService<List<AtividadeAPI1.API.Model.TaskModel>>();
    TaskModel.Id = taskService.Max(t => t.Id) + 1;
    taskService.Add(TaskModel);
    return Results.Created($"/task/{TaskModel.Id}", TaskModel);

});


app.MapPut("/atividadeAPI1/{id}", (int id, AtividadeAPI1.API.Model.TaskModel taskModel) =>
{
    var taskService = app.Services.GetRequiredService<List<AtividadeAPI1.API.Model.TaskModel>>();
    var existingTask = taskService.FirstOrDefault(t => t.Id == id);

    if (existingTask == null)
    {
        return Results.NotFound();
    }

    existingTask.Nome = taskModel.Nome;
    existingTask.Quantidade = taskModel.Quantidade;
    existingTask.Preco = taskModel.Preco;

    return Results.NoContent();

});

app.MapDelete("/atividadeAPI1/{id}", (int id) =>
{
    var taskService = app.Services.GetRequiredService<List<AtividadeAPI1.API.Model.TaskModel>>();
    var existingTask = taskService.FirstOrDefault(t => t.Id == id);

    if (existingTask == null)
    {
        return Results.NotFound();
    }

    taskService.Remove(existingTask);
    return Results.NoContent();

});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
