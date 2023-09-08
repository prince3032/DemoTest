using AutoMapper;
using DemoApplication.DTOs;
using DemoApplication.Models;

namespace DemoApplication.MapperProfile
{
    public class AutoMapperProfiles : Profile
    {
        protected internal AutoMapperProfiles()
        {
            CreateMap<Employee, EditEmployeeDTO>().ReverseMap();
            CreateMap<EmployeeSalary, EmployeeSalaryCreateDTO>().ReverseMap();
        }

    }
}
