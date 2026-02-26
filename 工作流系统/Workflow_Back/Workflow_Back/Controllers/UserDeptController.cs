using Microsoft.AspNetCore.Mvc;
using Workflow_Back.CommonControllers;
using Workflow_Back.Models;
using Workflow_Back.Services;

namespace Workflow_Back.Controllers
{
    /// <summary>
    /// 控制器
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class UserDeptController : CommonController<UserDeptController>
    {
        /// <summary>
        /// Service
        /// </summary>
        private IUserDeptService _UserDeptService;   

        public UserDeptController(ILogger<UserDeptController> logger,
                                IUserDeptService UserDeptService) : 
            base(logger)
        {
            _UserDeptService = UserDeptService;
        }

        /// <summary>
        /// 查询Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<UserDept> Get(int id)
        {
            // 1、查询
           return await _UserDeptService.GetAsync(id);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="value"></param>

        [HttpPost]
        public async Task<bool> Post(UserDept UserDept)
        {
            // 1、添加
            return await _UserDeptService.AddAsync(UserDept);
        }
    }
}