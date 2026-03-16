using AutoMapper;
using Workflow_Back.Models;

namespace Workflow_Back.Dtos
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // 定义 User 到 UserDto 的映射
            CreateMap<UserCreateDto, User>();
        }
    }
}
