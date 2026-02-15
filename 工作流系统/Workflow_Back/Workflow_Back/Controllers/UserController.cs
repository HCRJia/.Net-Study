using Microsoft.AspNetCore.Mvc;
using Workflow_Back.CommonControllers;
using Workflow_Back.Models;
using Workflow_Back.Service;

namespace Workflow_Back.Controllers
{
    /// <summary>
    /// 用户控制器
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class UserController : CommonController<UserController>
    {
        /// <summary>
        /// 用户Service
        /// </summary>
        private IUserService _userService;

        public UserController(ILogger<UserController> logger,
                                IUserService userService) :
            base(logger)
        {
            _userService = userService;
        }

        /// <summary>
        /// 查询用户Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            // 1、查询用户
            return await _userService.GetAsync(id);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="value"></param>

        [HttpPost]
        public async Task<bool> Post(User user)
        {
            // 1、添加用户
            return await _userService.AddAsync(user);
        }
    }
}
