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
    public class ItemPedidoController : ControllerBase
    {
        private readonly IItemPedidoService _service;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public ItemPedidoController(IItemPedidoService service, IMapper mapper, ILogger<ItemPedidoController> logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<ItemPedidoViewModel>> GetAll([FromQuery] Guid? pedidoId)
        {
            if (pedidoId.HasValue)
            {
                var items = await _service.GetByPedido(pedidoId.Value);
                return _mapper.Map<IEnumerable<ItemPedidoViewModel>>(items);
            }

            return _mapper.Map<IEnumerable<ItemPedidoViewModel>>(await _service.GetAll());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ItemPedidoViewModel>> Get(Guid id)
        {
            var item = _mapper.Map<ItemPedidoViewModel>(await _service.Get(id));
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<ActionResult> Post(ItemPedidoViewModel vm)
        {
            if (!ModelState.IsValid) return BadRequest();
            var item = _mapper.Map<ItemPedido>(vm);
            item.Id = Guid.NewGuid();
            try
            {
                await _service.Add(item);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                // estoque insuficiente
                return BadRequest(new { message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                // produto nao encontrado
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, ItemPedidoViewModel vm)
        {
            if (id != vm.Id) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            await _service.Update(_mapper.Map<ItemPedido>(vm));
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
