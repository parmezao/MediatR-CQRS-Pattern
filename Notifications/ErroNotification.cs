using MediatR;

namespace MediatR_CQRS.Notification
{
    public class ErroNotification : INotification
    {
        public string Erro { get; set; }
        public string PilhaErro { get; set; }
    }    
}