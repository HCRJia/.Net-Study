using AutoMapper;
using Workflow_Back.Contexts;
using Workflow_Back.Dtos;
using Workflow_Back.Fixtrues;
using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// Service接口
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        /// <summary>
        /// 工作流固定类
        /// </summary>
        public WorkflowFixtrue _workflowFixtrue { get; set; }

        public UserService(WorkflowFixtrue workflowFixtrue,
                            IMapper mapper)
        {
            _workflowFixtrue = workflowFixtrue;
            _mapper = mapper;
        }

        public async Task<User> GetAsync(int Id)
        {
            //1、查询数据
            return await _workflowFixtrue.db._UserRepository.FindByIdAsync(Id);
        }

        public async Task<bool> AddAsync(User User)
        {
            return await _workflowFixtrue.db._UserRepository.InsertAsync(User);
        }

        public Task<bool> CreateUserAsync(UserCreateDto userCreateDto)
        {
            // 1、Dto模型转化
            // 使用 AutoMapper 进行对象映射
            var user = _mapper.Map<User>(userCreateDto);

            throw new NotImplementedException();
        }
    }
}