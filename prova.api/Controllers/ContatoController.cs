using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MedGrupo.Api.ViewModels;
using MedGrupo.DomainModel.Entity;
using MedGrupo.DomainModel.Entity;
using MedGrupo.DomainModel.Interfaces.Services;

namespace MedGrupo.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase

    {
        private readonly IContatoService _ContatoService;

        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public ContatoController(IContatoService ContatoService, IMapper mapper, ILogger<ContatoController> logger)
        {
            _ContatoService = ContatoService;
            _mapper = mapper;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<ContatoViewModel>> GetAll()
        {
            _logger.LogInformation("Executing api/Contato -> GetAll");

            return _mapper.Map<IEnumerable<ContatoViewModel>>(await _ContatoService.GetAll());
        }

        [AllowAnonymous]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ContatoViewModel>> Get(Guid id)
        {
            _logger.LogInformation("Executing api/Contato -> Get");

            var Contato = _mapper.Map<ContatoViewModel>(await _ContatoService.Get(id));

            if (Contato == null) return NotFound();

            return Contato;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<ContatoViewModel>> Post(ContatoViewModel ContatoViewModel)
        {
            _logger.LogInformation("Executing api/Contato -> Post");

            if (!ModelState.IsValid) return BadRequest();
            return Ok(_ContatoService.Add(_mapper.Map<ContatoViewModel, Contato>(ContatoViewModel)));
        }
        [AllowAnonymous]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ContatoViewModel>> Put(Guid id, ContatoViewModel ContatoViewModel)
        {
            _logger.LogInformation("Executing api/Contato -> Put");

            if (id != ContatoViewModel.Id)
            {
                return BadRequest("The id entered is not the same as the one passed in the query.");
            }

            if (!ModelState.IsValid) return BadRequest();

            return Ok(_ContatoService.Update(_mapper.Map<ContatoViewModel, Contato>(ContatoViewModel)));
        }
        [AllowAnonymous]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ContatoViewModel>> Delete(Guid id)
        {
            _logger.LogInformation("Executing api/Contato -> Delete");

            var Contato = _mapper.Map<ContatoViewModel>(await _ContatoService.Get(id));

            return Ok(_ContatoService.Delete(id));
        }

    }
}
