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

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<ClienteViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ClienteViewModel>>(await _service.GetAll());
        }

        [AllowAnonymous]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ClienteViewModel>> Get(Guid id)
        {
            var cliente = _mapper.Map<ClienteViewModel>(await _service.Get(id));
            if (cliente == null) return NotFound();
            return cliente;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<ClienteViewModel>> Post(ClienteViewModel vm)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _service.Add(_mapper.Map<Cliente>(vm));
            return Ok();
        }

        [AllowAnonymous]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, ClienteViewModel vm)
        {
            if (id != vm.Id) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            await _service.Update(_mapper.Map<Cliente>(vm));
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
