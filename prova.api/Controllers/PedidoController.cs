using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MedGrupo.Api.ViewModels;
using MedGrupo.DomainModel.Entity;
using MedGrupo.DomainModel.Interfaces.Services;

namespace MedGrupo.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _service;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public PedidoController(IPedidoService service, IMapper mapper, ILogger<PedidoController> logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<PedidoViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<PedidoViewModel>>(await _service.GetAll());
        }

        [AllowAnonymous]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PedidoViewModel>> Get(Guid id)
        {
            var pedido = _mapper.Map<PedidoViewModel>(await _service.Get(id));
            if (pedido == null) return NotFound();
            return pedido;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Post(PedidoViewModel vm)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _service.Add(_mapper.Map<Pedido>(vm));
            return Ok();
        }

        [AllowAnonymous]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, PedidoViewModel vm)
        {
            if (id != vm.Id) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            await _service.Update(_mapper.Map<Pedido>(vm));
            return Ok();
        }

        [AllowAnonymous]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}
