using System;
using MediatR;

namespace MediatR_CQRS.Notification
{
    public class ProdutoCreateNotification : INotification
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }    
}