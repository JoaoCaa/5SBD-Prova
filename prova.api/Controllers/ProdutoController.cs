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
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _service;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public ProdutoController(IProdutoService service, IMapper mapper, ILogger<ProdutoController> logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<ProdutoViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _service.GetAll());
        }

        [AllowAnonymous]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> Get(Guid id)
        {
            var produto = _mapper.Map<ProdutoViewModel>(await _service.Get(id));
            if (produto == null) return NotFound();
            return produto;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Post(ProdutoViewModel vm)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _service.Add(_mapper.Map<Produto>(vm));
            return Ok();
        }

        [AllowAnonymous]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, ProdutoViewModel vm)
        {
            if (id != vm.Id) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            await _service.Update(_mapper.Map<Produto>(vm));
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
