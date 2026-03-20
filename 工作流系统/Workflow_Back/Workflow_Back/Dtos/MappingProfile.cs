using AutoMapper;
using Workflow_Back.Models;

namespace Workflow_Back.Dtos
{
    /// <summary>
    /// 1、配置映射关系
    ///  Dto和Model之间的映射
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // 1、定义UserCreateDto 和 User模型的映射
            CreateMap<UserCreateDto,User>();
            CreateMap<User, UserLoginResultDto>();
        }
    }
}
