using MediatR;

namespace MediatR_CQRS.Domain.Command
{
    public class ProdutoDeleteCommand : IRequest<string>
    {
            public int Id { get; set; }
    }    
}