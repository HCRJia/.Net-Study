using Workflow_Back.CommonControllersExtensions;
using Workflow_Back.CommonExceptions;
using Workflow_Back.CommonResults;
using Workflow_Back.Contexts;
using Workflow_Back.Fixtrues;
using Workflow_Back.Services;

namespace Workflow_Back
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 1、使用CommonController模块
            builder.Services.AddCommonControllers();

            // 2、实现配置 Services 和 Fixtrues
            builder.Services.AddScoped(typeof(WorkflowFixtrue));
             builder.Services.AddScoped<IDeptService, DeptService>();
             builder.Services.AddScoped<IResourceService, ResourceService>();
             builder.Services.AddScoped<IRoleService, RoleService>();
             builder.Services.AddScoped<IRoleResourceService, RoleResourceService>();
             builder.Services.AddScoped<ISystemService, SystemService>();
             builder.Services.AddScoped<IUserService, UserService>();
             builder.Services.AddScoped<IUserDeptService, UserDeptService>();
             builder.Services.AddScoped<IUserRoleService, UserRoleService>();
             builder.Services.AddScoped<IWorkflowService, WorkflowService>();
             builder.Services.AddScoped<IWorkflowAssignService, WorkflowAssignService>();
             builder.Services.AddScoped<IWorkflowCategoryService, WorkflowCategoryService>();
             builder.Services.AddScoped<IWorkflowFormService, WorkflowFormService>();
             builder.Services.AddScoped<IWorkflowInstanceService, WorkflowInstanceService>();
             builder.Services.AddScoped<IWorkflowInstanceFormService, WorkflowInstanceFormService>();
             builder.Services.AddScoped<IWorkflowNoticeService, WorkflowNoticeService>();
             builder.Services.AddScoped<IWorkflowOperationHistoryService, WorkflowOperationHistoryService>();
             builder.Services.AddScoped<IWorkflowTransitionHistoryService, WorkflowTransitionHistoryService>();
             builder.Services.AddScoped<IWorkflowUrgeService, WorkflowUrgeService>();
             builder.Services.AddScoped<IWorkflowsqlService, WorkflowsqlService>();

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
        }
    }
}
