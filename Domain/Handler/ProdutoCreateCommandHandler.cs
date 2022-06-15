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
    public class ProdutoCreateCommandHandler : IRequestHandler<ProdutoCreateCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Produto> _produtoRepository;

        public ProdutoCreateCommandHandler(
            IMediator mediator, 
            IRepository<Produto> produtoRepository)
        {
            _mediator = mediator;
            _produtoRepository = produtoRepository;
        }

        public async Task<string> Handle(ProdutoCreateCommand request, CancellationToken cancellationToken)
        {
            var produto = new Produto { Nome = request.Nome, Preco = request.Preco };

            try
            {
                // Add to repository
                await _produtoRepository.Add(produto);
                // Publish notification
                await _mediator.Publish(new ProdutoCreateNotification { Id = produto.Id, Nome = produto.Nome, Preco = produto.Preco });

                return await Task.FromResult("Produto criado com sucesso!");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ProdutoCreateNotification { Id = produto.Id, Nome = produto.Nome, Preco = produto.Preco });
                await _mediator.Publish(new ErroNotification { Erro = ex.Message, PilhaErro = ex.StackTrace });
                return await Task.FromResult("Ocorreu um erro no momento da criação");            
            }
        }
    }
}