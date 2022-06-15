using MediatR;

namespace MediatR_CQRS.Notification
{
    public class ProdutoDeleteNotification : INotification
    {
        public int Id { get; set; }
        public bool IsConcluido { get; set; }
    }    
}