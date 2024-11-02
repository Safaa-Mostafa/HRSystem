using AutoMapper;
using HRManagement.BL.DTO;
using HRManagement.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.BL.MappingProfile
{
    public class EmployeeMappings : Profile
    {
        public EmployeeMappings()
        {
            CreateMap<AddEmployeeDTO, Employee>().ReverseMap();
            CreateMap<EditEmployeeDTO, Employee>().ReverseMap();
            CreateMap<Employee, GetEmployeeDTO>()
               .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive == HRManagement.DAL.Data.Enums.Status.Active))
               .ReverseMap()
               .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive ? HRManagement.DAL.Data.Enums.Status.Active : HRManagement.DAL.Data.Enums.Status.Deactive));


        }
    }
}
