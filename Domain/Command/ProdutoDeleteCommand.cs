using System;
using MediatR;

namespace MediatR_CQRS.Domain.Command
{
    public class ProdutoDeleteCommand : IRequest<string>
    {
        public Guid Id { get; set; }
    }    
}