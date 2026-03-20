using Microsoft.AspNetCore.Mvc;
using Workflow_Back.CommonControllers;
using Workflow_Back.Models;
using Workflow_Back.Services;

namespace Workflow_Back.Controllers
{
    /// <summary>
    /// 用户部门关联模型控制器
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class UserDeptController : CommonController<UserDeptController>
    {
        /// <summary>
        /// 用户部门关联模型Service
        /// </summary>
        private IUserDeptService _UserDeptService;   

        public UserDeptController(ILogger<UserDeptController> logger,
                                IUserDeptService UserDeptService) : 
            base(logger)
        {
            _UserDeptService = UserDeptService;
        }

        /// <summary>
        /// 查询用户部门关联模型Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<UserDept> Get(int id)
        {
            // 1、查询用户部门关联模型
           return await _UserDeptService.GetAsync(id);
        }

        /// <summary>
        /// 添加用户部门关联模型
        /// </summary>
        /// <param name="value"></param>

        [HttpPost]
        public async Task<bool> Post(UserDept UserDept)
        {
            // 1、添加用户部门关联模型
            return await _UserDeptService.AddAsync(UserDept);
        }
    }
}