using AutoMapper;
using Mc2.CrudTest.Presentation.Application.Dtos;
using Mc2.CrudTest.Presentation.Shared.Entities;
using MediatR;

namespace Mc2.CrudTest.Presentation.Application.Features.Commands.Edit;

public record DeleteCustomerCommand(int Id) : IRequest<int>;

public class DeleteCustomerCommanddHandler : IRequestHandler<DeleteCustomerCommand, int>
{
    private readonly IMapper _mapper;
    private int Id;

    public DeleteCustomerCommanddHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<int> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));

        Id = request.Id;

        //TODO: Delete customer from database

        return Id;
    }
}

