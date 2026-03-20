using Microsoft.AspNetCore.Mvc;
using Workflow_Back.CommonControllers;
using Workflow_Back.Dtos;
using Workflow_Back.Models;
using Workflow_Back.Services;

namespace Workflow_Back.Controllers
{
    /// <summary>
    /// 用户模型控制器
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class UserController : CommonController<UserController>
    {
        /// <summary>
        /// 用户模型Service
        /// </summary>
        private IUserService _UserService;   

        public UserController(ILogger<UserController> logger,
                                IUserService UserService) : 
            base(logger)
        {
            _UserService = UserService;
        }

        /// <summary>
        /// 查询用户模型Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            // 1、查询用户模型
           return await _UserService.GetAsync(id);
        }

        /*/// <summary>
        /// 添加用户模型
        /// </summary>
        /// <param name="value"></param>

        [HttpPost]
        public async Task<bool> Post(User User)
        {
            // 1、添加用户模型
            return await _UserService.AddAsync(User);
        }*/

        /// <summary>
        /// 用户创建接口
        /// </summary>
        /// <param name="userCreateDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> UserCreateAsync(UserCreateDto userCreateDto)
        {
            return await _UserService.UserCreateAsync(userCreateDto);
        }
    }
}