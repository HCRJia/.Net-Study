using Workflow_Back.CommonControllersExtensions;
using Workflow_Back.CommonExceptions;
using Workflow_Back.CommonResults;
using Workflow_Back.Fixtrues;
using Workflow_Back.Service;
using Workflow_Back.Services;

var builder = WebApplication.CreateBuilder(args);

// 1、使用CommonController模块
builder.Services.AddCommonControllers();

// 2、实现配置 Services 和 Fixtrues
builder.Services.AddScoped(typeof(WorkflowFixtrue));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();

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
