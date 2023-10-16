using AutoMapper;
using Mc2.CrudTest.Presentation.Application.Dtos;
using Mc2.CrudTest.Presentation.Shared.Entities;

namespace Mc2.CrudTest.Presentation.Application.Features.Mappings;

public class CustomerMapping : Profile
{
    public CustomerMapping()
    {
        CreateMap<Customer, CustomerDto>()
            .ForMember(c => c.Id, opt => opt.MapFrom(s => s.Id))
            .ForMember(c => c.Firstname, opt => opt.MapFrom(s => s.Firstname))
            .ForMember(c => c.Lastname, opt => opt.MapFrom(s => s.Lastname))
            .ForMember(c => c.DateOfBirth, opt => opt.MapFrom(s => s.DateOfBirth))
            .ForMember(c => c.PhoneNumber, opt => opt.MapFrom(s => s.PhoneNumber))
            .ForMember(c => c.Email, opt => opt.MapFrom(s => s.Email))
            .ForMember(c => c.BankAccountNumber, opt => opt.MapFrom(s => s.BankAccountNumber));
    }
}
