using System.Threading.Tasks;
using MediatR;
using MediatR_CQRS.Domain.Command;
using MediatR_CQRS.Domain.Entity;
using MediatR_CQRS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MediatR_CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Produto> _repository;

        public ProdutosController(
            IMediator mediator, 
            IRepository<Produto> produtosRepository)
        {
            _mediator = mediator;
            _repository = produtosRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _repository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProdutoCreateCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        
        [HttpPut]
        public async Task<IActionResult> Put(ProdutoUpdateCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var obj = new ProdutoDeleteCommand { Id = id };
            var result = await _mediator.Send(obj);
            return Ok(result);
        }        
    }
}