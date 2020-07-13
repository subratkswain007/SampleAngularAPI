using AutoMapper;

namespace SampleAngularAPI.Model
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EmployeeModel, Employee>().ReverseMap();           
        }
    }
}
