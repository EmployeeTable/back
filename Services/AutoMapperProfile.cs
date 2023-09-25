using AutoMapper;
using EmployeesTable.DTO;
using EmployeesTable.Models;

namespace EmployeesTable.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeAddressDTO>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.age, opt => opt.MapFrom(src => src.age))
                .ForMember(dest => dest.addresses, opt => opt.MapFrom(src => src.addresses.Select(a => new AddressDTo { description = a.description })));

            CreateMap<EmployeeAddressDTO, Employee>();
            CreateMap<AddressDTo, Address>();
            CreateMap<Address, AddressDTo>()
            .ForMember(dest => dest.description, opt => opt.MapFrom(src => src.description));

        }
    }
}
