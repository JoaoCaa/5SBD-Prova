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
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public ClienteController(IClienteService service, IMapper mapper, ILogger<ClienteController> logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<ClienteViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ClienteViewModel>>(await _service.GetAll());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ClienteViewModel>> Get(Guid id)
        {
            var cliente = _mapper.Map<ClienteViewModel>(await _service.Get(id));
            if (cliente == null) return NotFound();
            return cliente;
        }

        [HttpPost]
        public async Task<ActionResult<ClienteViewModel>> Post(ClienteViewModel vm)
        {
            if (!ModelState.IsValid) return BadRequest();
            var cliente = _mapper.Map<Cliente>(vm);
            // ensure server generates the id
            cliente.Id = Guid.NewGuid();
            await _service.Add(cliente);
            return Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, ClienteViewModel vm)
        {
            if (id != vm.Id) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            await _service.Update(_mapper.Map<Cliente>(vm));
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
