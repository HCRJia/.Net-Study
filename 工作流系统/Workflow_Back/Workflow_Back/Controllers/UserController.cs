using Microsoft.AspNetCore.Mvc;
using Workflow_Back.CommonControllers;
using Workflow_Back.Dtos;
using Workflow_Back.Models;
using Workflow_Back.Services;

namespace Workflow_Back.Controllers
{
    /// <summary>
    /// 控制器
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class UserController : CommonController<UserController>
    {
        /// <summary>
        /// Service
        /// </summary>
        private IUserService _UserService;   

        public UserController(ILogger<UserController> logger,
                                IUserService UserService) : 
            base(logger)
        {
            _UserService = UserService;
        }

        /// <summary>
        /// 查询Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            // 1、查询
           return await _UserService.GetAsync(id);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="value"></param>

        //[HttpPost]
        //public async Task<bool> Post(User User)
        //{
        //    // 1、添加
        //    return await _UserService.AddAsync(User);
        //}

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="userCreateDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task CreateUser(UserCreateDto userCreateDto)
        {
            _UserService.CreateUserAsync(userCreateDto);
        }
    }
}