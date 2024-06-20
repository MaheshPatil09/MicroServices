using AutoMapper;
using WebApplication4.Dto;
using WebApplication4.Entities;

namespace WebApplication4.Common
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<StudentEntity,StudentModel>().ReverseMap();
        }
    }
}
