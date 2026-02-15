using JadeFramework.Dapper.DbContext;
using Workflow_Back.Repositorise;

namespace Workflow_Back.Contexts
{
    public interface IWorkflowDbContext : IDapperDbContext
    {
        //1、依赖IUserRepository
        public IUserRepository userRepository { get; }
    }
}
