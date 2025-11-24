using AutoMapper;
using Prova.Api.ViewModels;
using Prova.DomainModel.Entity;
using Prova.DomainModel.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Prova.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _service;
        private readonly IMapper _mapper;

        public PedidoController(IPedidoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PedidoViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<PedidoViewModel>>(await _service.GetAll());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PedidoViewModel>> Get(Guid id)
        {
            var pedido = _mapper.Map<PedidoViewModel>(await _service.Get(id));
            if (pedido == null) return NotFound();
            return pedido;
        }

        [HttpPost]
        public async Task<ActionResult> Post(PedidoViewModel vm)
        {
            if (!ModelState.IsValid) return BadRequest();
            var pedido = _mapper.Map<Pedido>(vm);
            pedido.Id = Guid.NewGuid();
            if (pedido.Items != null)
            {
                foreach (var it in pedido.Items)
                {
                    it.Id = Guid.NewGuid();
                    it.PedidoId = pedido.Id;
                }
            }
            await _service.Add(pedido);
            return Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, PedidoViewModel vm)
        {
            vm.Id = id;
            if (!ModelState.IsValid) return BadRequest();
            await _service.Update(_mapper.Map<Pedido>(vm));
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}
