using System;

namespace MediatR_CQRS.Domain.Entity
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }        
    }    
}