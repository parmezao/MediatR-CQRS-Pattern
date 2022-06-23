using System;
using MediatR;

namespace MediatR_CQRS.Domain.Command
{
    public class ProdutoCreateCommand : IRequest<string>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }    
}