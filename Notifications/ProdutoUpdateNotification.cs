using MediatR;

namespace MediatR_CQRS.Notification
{
    public class ProdutoUpdateNotification : INotification
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public bool IsConcluido { get; set; }
    }    
}