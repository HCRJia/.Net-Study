using Workflow_Back.CommonControllersExtensions;
using Workflow_Back.CommonExceptions;
using Workflow_Back.CommonResults;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCommonControllers();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
