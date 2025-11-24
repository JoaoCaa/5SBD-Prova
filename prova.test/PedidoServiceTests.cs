using Moq;
using Prova.DomainModel.Entity;
using Prova.DomainModel.Interfaces.Repositories;
using Prova.DomainModel.Interfaces.UoW;
using Prova.DomainService;

namespace prova.test
{
    [TestFixture]
    public class PedidoServiceTests
    {
        private Mock<IPedidoRepository> _repoMock = null!;
        private Mock<IUnitOfWork> _uowMock = null!;
        private PedidoService _service = null!;

        [SetUp]
        public void Setup()
        {
            _repoMock = new Mock<IPedidoRepository>();
            _uowMock = new Mock<IUnitOfWork>();
            _service = new PedidoService(_repoMock.Object, _uowMock.Object);
        }

        [Test]
        public async Task Add_Should_SetAtivo_CreateAndCommit()
        {
            var pedido = new Pedido { Id = Guid.NewGuid(), Cliente = new Cliente { Id = Guid.NewGuid(), Nome = "C" }, Items = new List<ItemPedido>() };

            await _service.Add(pedido);

            _repoMock.Verify(r => r.Create(It.Is<Pedido>(p => p == pedido)), Times.Once);
            _uowMock.Verify(u => u.CommitAsync(), Times.Once);
        }

        [Test]
        public async Task Get_Should_ReturnPedido_FromRepository()
        {
            var id = Guid.NewGuid();
            var pedido = new Pedido { Id = id, Cliente = new Cliente { Id = Guid.NewGuid(), Nome = "C" }, Items = new List<ItemPedido>() };
            _repoMock.Setup(r => r.GetPedido(id)).ReturnsAsync(pedido);

            var result = await _service.Get(id);

            Assert.AreSame(pedido, result);
        }
    }
}
