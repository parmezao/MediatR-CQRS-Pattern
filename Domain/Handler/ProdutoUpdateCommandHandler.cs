using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatR_CQRS.Domain.Command;
using MediatR_CQRS.Domain.Entity;
using MediatR_CQRS.Notification;
using MediatR_CQRS.Repository;

namespace MediatR_CQRS.Domain.Handler
{
    public class ProdutoUpdateCommandHandler : IRequestHandler<ProdutoUpdateCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Produto> _repository;
        public ProdutoUpdateCommandHandler(IMediator mediator, IRepository<Produto> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }
        public async Task<string> Handle(ProdutoUpdateCommand request, CancellationToken cancellationToken)
        {
            var produto = new Produto { Id = request.Id, Nome = request.Nome, Preco = request.Preco };

            try
            {
                await _repository.Edit(produto);

                await _mediator.Publish(new ProdutoUpdateNotification
                { 
                    Id = produto.Id.GetHashCode(), 
                    Nome = produto.Nome, 
                    Preco = produto.Preco 
                });

                return await Task.FromResult("Produto alterado com sucesso");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ProdutoUpdateNotification 
                { 
                    Id = produto.Id.GetHashCode(), 
                    Nome = produto.Nome, 
                    Preco = produto.Preco 
                });
                
                await _mediator.Publish(new ErroNotification { Erro = ex.Message, PilhaErro = ex.StackTrace });
                
                return await Task.FromResult("Ocorreu um erro no momento da alteração");
            }
        }
    }    
}