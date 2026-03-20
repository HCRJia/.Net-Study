using AutoMapper;
using Workflow_Back.Contexts;
using Workflow_Back.Dtos;
using Workflow_Back.Fixtrues;
using Workflow_Back.Models;

namespace Workflow_Back.Services
{
    /// <summary>
    /// 用户模型Service接口
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// 工作流固定类
        /// </summary>
        public WorkflowFixtrue _workflowFixtrue { get; set; }
        private readonly IMapper _mapper;  // 映射接口

        public UserService(WorkflowFixtrue workflowFixtrue,
                           IMapper mapper)
        {
            _workflowFixtrue = workflowFixtrue;
            _mapper = mapper;
        }

        public async Task<User> GetAsync(int Id)
        {
            //1、查询用户模型数据
            return await _workflowFixtrue.db.Users.FindByIdAsync(Id);
        }

        public async Task<bool> AddAsync(User User)
        {
            return await _workflowFixtrue.db.Users.InsertAsync(User);
        }

        /// <summary>
        /// 用户创建实现
        /// </summary>
        /// <param name="userCreateDto"></param>
        /// <returns></returns>
        public async Task<bool> UserCreateAsync(UserCreateDto userCreateDto)
        {
            // 1、UserCreateDto模型映射
            User user = _mapper.Map<User>(userCreateDto);

            //2、实现用户创建
            return await  _workflowFixtrue.db.Users.InsertAsync(user);
        }
    }
}