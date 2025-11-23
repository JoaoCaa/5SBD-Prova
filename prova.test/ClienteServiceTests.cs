using System;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using MedGrupo.DomainModel.Entity;
using MedGrupo.DomainModel.Interfaces.Repositories;
using MedGrupo.DomainModel.Interfaces.UoW;
using MedGrupo.DomainService;

namespace prova.test
{
    [TestFixture]
    public class ClienteServiceTests
    {
        private Mock<IClienteRepository> _repoMock = null!;
        private Mock<IUnitOfWork> _uowMock = null!;
        private ClienteService _service = null!;

        [SetUp]
        public void Setup()
        {
            _repoMock = new Mock<IClienteRepository>();
            _uowMock = new Mock<IUnitOfWork>();
            _service = new ClienteService(_repoMock.Object, _uowMock.Object);
        }

        [Test]
        public async Task Add_Should_SetAtivo_CreateAndCommit()
        {
            var cliente = new Cliente { Id = Guid.NewGuid(), Nome = "Teste", Documento = "123", Email = "a@b.com", Telefone = "9999" };

            await _service.Add(cliente);

            _repoMock.Verify(r => r.Create(It.Is<Cliente>(c => c == cliente && c.Ativo)), Times.Once);
            _uowMock.Verify(u => u.CommitAsync(), Times.Once);
        }

        [Test]
        public async Task Get_Should_ReturnCliente_FromRepository()
        {
            var id = Guid.NewGuid();
            var cliente = new Cliente { Id = id, Nome = "X" };
            _repoMock.Setup(r => r.Read(id)).ReturnsAsync(cliente);

            var result = await _service.Get(id);

            Assert.AreSame(cliente, result);
        }
    }
}
