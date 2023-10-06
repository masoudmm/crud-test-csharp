using AutoMapper;
using Mc2.CrudTest.Presentation.Application.Dtos;
using Mc2.CrudTest.Presentation.Shared.Entities;

namespace Mc2.CrudTest.Presentation.Application.Features.Mappings;

public class GetCustomerMapping : Profile
{
    public GetCustomerMapping()
    {
        CreateMap<Customer, CustomerDto>()
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
            .ForMember(d => d.Firstname, opt => opt.MapFrom(s => s.Firstname))
            .ForMember(d => d.Lastname, opt => opt.MapFrom(s => s.Lastname))
            .ForMember(d => d.DateOfBirth, opt => opt.MapFrom(s => s.DateOfBirth))
            .ForMember(d => d.PhoneNumber, opt => opt.MapFrom(s => s.PhoneNumber))
            .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email))
            .ForMember(d => d.BankAccountNumber, opt => opt.MapFrom(s => s.BankAccountNumber));
    }
}
